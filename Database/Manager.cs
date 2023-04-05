using System;
using System.IO;
using System.Collections.Generic;

using BudgetWatcher.Database.Schemas;

using Microsoft.Office.Interop.Access.Dao;
using Access = Microsoft.Office.Interop.Access;
using System.Runtime.InteropServices;

namespace BudgetWatcher.Database
{
    public class Manager
    {
        #region Fields
        public static readonly string DatabaseFilePath = Path.Combine(AppContext.BaseDirectory, "BudgetWatcher.accdb");
        static readonly Manager s_Instance = new Manager();

        Access.Application m_AccessApp = null;
        #endregion Fields

        #region Properties
        public static Manager Instance { get => s_Instance; }
        public static Access.Dao.Database DbInstance
        {
            get
            {
                try
                {
                    return Instance.m_AccessApp.CurrentDb();
                }
                catch (COMException)
                {
                    Instance.HandleAccesProcessStopped();
                }
                return Instance.m_AccessApp.CurrentDb(); ;
            }
        }
        #endregion Properties

        #region Events
        public Action OnDatabaseLoad;
        public Action OnDatabaseLoaded;

        public Action OnDatabaseCreate;
        public Action OnDatabaseCreated;

        public Action OnDatabaseOpen;
        public Action OnDatabaseOpened;

        public Action OnDatabaseClose;
        public Action OnDatabaseClosed;

        public Action OnDatabaseProcessRestart;
        public Action OnDatabaseProcessRestarted;
        #endregion

        #region Public API
        public List<Expense> SelectAllExpenses(DateTime startDate, DateTime endDate)
        {
            List<Expense> expenses = new List<Expense>();

            Recordset rs = DbInstance.OpenRecordset(Expense.TableName, RecordsetTypeEnum.dbOpenDynaset);

            while (!rs.EOF)
            {
                DateTime expenseDate = rs.Fields[Expense.Fields.Date].Value;

                if (startDate <= expenseDate && expenseDate <= endDate)
                {
                    Expense expense = new Expense();
                    expense.LoadFromRecordset(rs);

                    expenses.Add(expense);
                }

                rs.MoveNext();
            }

            rs.Close();

            return expenses;
        }

        public List<DbObject> SelectAll<DbObject>(string tableName) where DbObject : IDatabaseObject, new()
        {
            List<DbObject> dbObjects = new List<DbObject>();

            Recordset rs = DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);

            while (!rs.EOF)
            {
                DbObject dbObject = new DbObject();
                dbObject.LoadFromRecordset(rs);

                dbObjects.Add(dbObject);

                rs.MoveNext();
            }

            rs.Close();

            return dbObjects;
        }

        public void SelectFrom<DbObject>(string tableName, int id, DbObject dbObject) where DbObject : IDatabaseObject
        {
            Recordset rs = FindFirst(tableName, dbObject.IdTableField, id);

            dbObject.LoadFromRecordset(rs);

            rs.Close();
        }

        public void InsertInto<DbObject>(string tableName, DbObject dbObject) where DbObject : IDatabaseObject
        {
            Recordset rs = DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.AddNew();

            typeof(DbObject).GetProperty(dbObject.IdProperty).SetValue(dbObject, (int)rs.Fields[dbObject.IdTableField].Value);

            dbObject.FillInRecordset(rs);

            rs.Update();
            rs.Close();
        }

        public void Update<DbObject>(string tableName, DbObject dbObject) where DbObject : IDatabaseObject
        {
            Recordset rs = FindFirst(tableName, dbObject.IdTableField, dbObject.ID);

            rs.Edit();
            dbObject.FillInRecordset(rs);

            rs.Update();
            rs.Close();
        }

        public void Delete<DbObject>(string tableName, DbObject dbObject) where DbObject : IDatabaseObject
        {
            Recordset rs = FindFirst(tableName, dbObject.IdTableField, dbObject.ID);

            rs.Delete();

            rs.Close();
        }

        public List<Tuple<int, string>> Peek(string tableName, string intField, string stringField)
        {
            List<Tuple<int, string>> objects = new List<Tuple<int, string>>();

            Recordset rs = DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);

            while (!rs.EOF)
            {
                objects.Add(new Tuple<int, string>(rs.Fields[intField].Value, rs.Fields[stringField].Value));

                rs.MoveNext();
            }

            rs.Close();

            return objects;
        }

        public void HandleAccesProcessStopped()
        {
            OnDatabaseProcessRestart?.Invoke();

            m_AccessApp = null;

            OpenOrCreateDatabase();

            OnDatabaseProcessRestarted?.Invoke();
        }

        public void OpenOrCreateDatabase()
        {
            if (m_AccessApp != null) return;

            OnDatabaseLoad?.Invoke();

            m_AccessApp = new Access.Application();

            if (File.Exists(DatabaseFilePath))
            {
                OpenDatabase();
            }
            else
            {
                CreateDatabase();
            }

            OnDatabaseLoaded?.Invoke();
        }

        public void CloseDatabase()
        {
            if (m_AccessApp == null) return;

            OnDatabaseClose?.Invoke();

            m_AccessApp.CloseCurrentDatabase();
            m_AccessApp.Quit();
            m_AccessApp = null;

            OnDatabaseClosed?.Invoke();
        }
        #endregion Public API

        #region Private API
        void OpenDatabase()
        {
            OnDatabaseOpen?.Invoke();

            m_AccessApp.OpenCurrentDatabase(DatabaseFilePath);

            OnDatabaseOpened?.Invoke();
        }

        void CreateDatabase()
        {
            OnDatabaseCreate?.Invoke();

            m_AccessApp.NewCurrentDatabase(DatabaseFilePath);

            CreateIncomesTable();
            CreateCategoriesTable();
            CreateFrequenciesTable();
            CreateExpensesTable();

            InsertDefaultData();

            OnDatabaseCreated?.Invoke();
        }

        Recordset FindFirst(string tableName, string idField, int id)
        {
            Recordset rs = DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(idField + " = " + id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No record with ID " + id + " matched on table " + tableName);
            }

            return rs;
        }
        #endregion Private API

        #region Database Definitions
        void CreateIncomesTable()
        {
            // create table definition
            TableDef tableDef = DbInstance.CreateTableDef(Income.TableName);

            // create fields
            Field id = tableDef.CreateField(Income.Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Income.Fields.Name, DataTypeEnum.dbText);
            Field value = tableDef.CreateField(Income.Fields.Value, DataTypeEnum.dbDouble);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(value);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(Income.TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(Income.Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            DbInstance.TableDefs.Append(tableDef);
        }

        void CreateCategoriesTable()
        {
            // create table definition
            TableDef tableDef = DbInstance.CreateTableDef(ExpenseCategory.TableName);

            // create fields
            Field id = tableDef.CreateField(ExpenseCategory.Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(ExpenseCategory.Fields.Name, DataTypeEnum.dbText);
            Field description = tableDef.CreateField(ExpenseCategory.Fields.Description, DataTypeEnum.dbText);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(description);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(ExpenseCategory.TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(ExpenseCategory.Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            DbInstance.TableDefs.Append(tableDef);
        }

        void CreateFrequenciesTable()
        {
            // create table definition
            TableDef tableDef = DbInstance.CreateTableDef(ExpenseFrequency.TableName);

            // create fields
            Field id = tableDef.CreateField(ExpenseFrequency.Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(ExpenseFrequency.Fields.Name, DataTypeEnum.dbText);
            Field days = tableDef.CreateField(ExpenseFrequency.Fields.Days, DataTypeEnum.dbInteger);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(days);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(ExpenseFrequency.TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(ExpenseFrequency.Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            DbInstance.TableDefs.Append(tableDef);
        }

        void CreateExpensesTable()
        {
            // create table definition
            TableDef tableDef = DbInstance.CreateTableDef(Expense.TableName);

            // create fields
            Field id = tableDef.CreateField(Expense.Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Expense.Fields.Name, DataTypeEnum.dbText);
            Field value = tableDef.CreateField(Expense.Fields.Value, DataTypeEnum.dbDouble);
            Field date = tableDef.CreateField(Expense.Fields.Date, DataTypeEnum.dbDate);
            Field categoryId = tableDef.CreateField(Expense.Fields.CategoryId, DataTypeEnum.dbLong);
            Field frequencyId = tableDef.CreateField(Expense.Fields.FrequencyId, DataTypeEnum.dbLong);
            Field details = tableDef.CreateField(Expense.Fields.Details, DataTypeEnum.dbMemo);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(value);
            tableDef.Fields.Append(date);
            tableDef.Fields.Append(categoryId);
            tableDef.Fields.Append(frequencyId);
            tableDef.Fields.Append(details);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(Expense.TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(Expense.Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            DbInstance.TableDefs.Append(tableDef);

            // define foreign key categoryId references ExpenseCategories.id
            categoryId.Required = true;

            Relation categoryRelation = DbInstance.CreateRelation();
            categoryRelation.Name = Expense.TableName + "_" + ExpenseCategory.TableName + "_ForeignKey";
            categoryRelation.Table = ExpenseCategory.TableName;
            categoryRelation.ForeignTable = Expense.TableName;
            categoryRelation.Attributes = (int)RelationAttributeEnum.dbRelationUpdateCascade | (int)RelationAttributeEnum.dbRelationDeleteCascade;

            Field fkCategoryField = categoryRelation.CreateField(ExpenseCategory.Fields.ID);
            fkCategoryField.ForeignName = Expense.Fields.CategoryId;
            categoryRelation.Fields.Append(fkCategoryField);

            DbInstance.Relations.Append(categoryRelation);

            // define foreign key frequencyId references ExpenseFrequencies.id
            frequencyId.Required = true;

            Relation frequencyRelation = Manager.DbInstance.CreateRelation();
            frequencyRelation.Name = Expense.TableName + "_" + ExpenseFrequency.TableName + "_ForeignKey";
            frequencyRelation.Table = ExpenseFrequency.TableName;
            frequencyRelation.ForeignTable = Expense.TableName;
            frequencyRelation.Attributes = (int)RelationAttributeEnum.dbRelationUpdateCascade | (int)RelationAttributeEnum.dbRelationDeleteCascade;

            Field fkFrequencyField = frequencyRelation.CreateField(ExpenseFrequency.Fields.ID);
            fkFrequencyField.ForeignName = Expense.Fields.FrequencyId;
            frequencyRelation.Fields.Append(fkFrequencyField);

            DbInstance.Relations.Append(frequencyRelation);
        }

        void InsertDefaultData()
        {
            ExpenseCategory category = new ExpenseCategory();
            foreach (var value in new Tuple<string, string>[] {
                new Tuple<string, string>("Abonamente", "netflix, internet, telefonie, etc..."),
                new Tuple<string, string>("Altele", "altele..."),
                new Tuple<string, string>("Animale de companie", "hrană pentru animale, jucării, îngrijire veterinară, etc..."),
                new Tuple<string, string>("Asigurări", "asigurare auto, asigurare de sănătate, asigurare de viață, etc..."),
                new Tuple<string, string>("Chirie", "chirie, etc..."),
                new Tuple<string, string>("Cosmetice", "creme, parfumuri, etc..."),
                new Tuple<string, string>("Donații", "contribuții la organizații caritabile, fundații, cauze, etc..."),
                new Tuple<string, string>("Divertisment", "filme, masa la restaurant, etc..."),
                new Tuple<string, string>("Educație", "cursuri, manuale, etc..."),
                new Tuple<string, string>("Educație și formare", "cursuri de dezvoltare personală, învățare online, materiale de studiu, etc..."),
                new Tuple<string, string>("Hobby-uri", "articole de pictură, jocuri de societate, colecționare, etc..."),
                new Tuple<string, string>("Impozite", "impozit pe proprietate, impozit pe venit, etc..."),
                new Tuple<string, string>("Împrumuturi și datorii", "rate la împrumuturi, carduri de credit, datorii la persoane fizice sau juridice, etc..."),
                new Tuple<string, string>("Îmbrăcăminte", "haine, încălțăminte, etc..."),
                new Tuple<string, string>("Îngrijire personală", "cosmetice, produse de îngrijire a pielii, tunsori, etc..."),
                new Tuple<string, string>("Pentru casă", "detergenți, mobilă, frigider, etc..."),
                new Tuple<string, string>("Pentru mașină", "benzină, motorină, spălătorie, etc..."),
                new Tuple<string, string>("Produse Alimentare", "pâine, lapte, ouă, etc..."),
                new Tuple<string, string>("Reparații", "reparații auto, reparații casnice, etc..."),
                new Tuple<string, string>("Sănătate", "analize medicale, medicamente, etc..."),
                new Tuple<string, string>("Servicii", "spălătorie, croitorie, etc..."),
                new Tuple<string, string>("Tehnologie", "telefoane, laptopuri, tablete, accesorii, etc..."),
                new Tuple<string, string>("Transport", "bilete de avion, bilete de autobuz, etc..."),
                new Tuple<string, string>("Vacanțe și călătorii", "cazare, bilete de avion, bilete de autocar, asigurare de călătorie, etc..."),
                new Tuple<string, string>("Petreceri și evenimente", "cadouri pentru ziua de naștere, botezuri, nunți, etc..."),
            })
            {
                category.Name = value.Item1;
                category.Description = value.Item2;
                category.Insert();
            }

            ExpenseFrequency frequency = new ExpenseFrequency();
            foreach (var value in new Tuple<string, int>[] {
                new Tuple<string, int>("Fără frecvență", 0),
                new Tuple<string, int>("Zilnic", 1),
                new Tuple<string, int>("Săptămânal", 7),
                new Tuple<string, int>("Lunar", 30),
                new Tuple<string, int>("Trimestrial", 90),
                new Tuple<string, int>("Semestrial", 182),
                new Tuple<string, int>("Anual", 365),
            })
            {
                frequency.Name = value.Item1;
                frequency.Days = value.Item2;
                frequency.Insert();
            }
        }
        #endregion Database Definitions
    }
}
