using Microsoft.Office.Interop.Access.Dao;
using System;

namespace BudgetDjinni.Database.Schemas
{
    public class ExpenseCategory : IDatabaseObject, IEquatable<ExpenseCategory>
    {
        #region Database Table Definitions
        public static readonly string TableName = "ExpenseCategories";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Description = "Description";
        }

        public static void CreateTable()
        {
            // create table definition
            TableDef tableDef = Manager.DbInstance.CreateTableDef(TableName);

            // create fields
            Field id = tableDef.CreateField(Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Fields.Name, DataTypeEnum.dbText);
            Field description = tableDef.CreateField(Fields.Description, DataTypeEnum.dbText);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(description);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            Manager.DbInstance.TableDefs.Append(tableDef);
        }
        #endregion Database Table Definitions

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion Properties

        #region Constructors
        public ExpenseCategory(string name, string description)
        {
            Id = -1;
            Name = name;
            Description = description;
        }

        public ExpenseCategory() : this("Empty Category", "-") { }

        public ExpenseCategory(int id)
        {
            LoadFromId(id);
        }
        #endregion Constructors

        #region Public API
        public void LoadFromId(int id)
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Category with ID " + id + " matched");
            }

            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Description = (string)rs.Fields[Fields.Description].Value;

            rs.Close();
        }

        public void Save()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);

            rs.AddNew();
            Id = (int)rs.Fields[Fields.ID].Value;

            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Description].Value = Description;

            rs.Update();
            rs.Close();
        }

        public void Update()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + Id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Category with ID " + Id + " matched");
            }

            rs.Edit();
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Description].Value = Description;

            rs.Update();
            rs.Close();
        }

        public void Delete()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + Id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Category with ID " + Id + " matched");
            }

            rs.Delete();

            rs.Close();
        }

        public bool Equals(ExpenseCategory other) => (Id == other.Id) && (Name == other.Name) && (Description == other.Description);
        public override bool Equals(object obj) => Equals(obj as ExpenseCategory);

        #endregion Public API
    }
}
