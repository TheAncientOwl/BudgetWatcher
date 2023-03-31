using BudgetWatcher.Database.Schemas;
using Microsoft.Office.Interop.Access.Dao;
using System;
using System.IO;
using System.Collections.Generic;

using Access = Microsoft.Office.Interop.Access;

namespace BudgetWatcher.Database
{
    public class Manager
    {
        #region Fields
        public static readonly string DatabaseFilePath = Path.Combine(AppContext.BaseDirectory, "BudgetDjinni.accdb");
        static readonly Manager s_Instance = new Manager();

        Access.Application m_AccessApp = null;
        #endregion Fields

        #region Properties
        public static Manager Instance { get => s_Instance; }
        public static Access.Dao.Database DbInstance { get => Instance.m_AccessApp.CurrentDb(); }
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
        #endregion

        #region Public API

        public List<Tuple<int, string>> PeekCategories()
        {
            List<Tuple<int, string>> categories = new List<Tuple<int, string>>();

            Recordset rs = DbInstance.OpenRecordset(ExpenseCategory.TableName, RecordsetTypeEnum.dbOpenDynaset);

            while(!rs.EOF)
            {
                categories.Add(new Tuple<int, string>(rs.Fields[ExpenseCategory.Fields.ID].Value, 
                                                      rs.Fields[ExpenseCategory.Fields.Name].Value));

                rs.MoveNext();
            }

            rs.Close();

            return categories;
        }

        public List<Tuple<int, string>> PeekFrequencies()
        {
            List<Tuple<int, string>> frequencies = new List<Tuple<int, string>>();

            Recordset rs = DbInstance.OpenRecordset(ExpenseFrequency.TableName, RecordsetTypeEnum.dbOpenDynaset);

            while (!rs.EOF)
            {
                frequencies.Add(new Tuple<int, string>(rs.Fields[ExpenseFrequency.Fields.ID].Value,
                                                      rs.Fields[ExpenseFrequency.Fields.Name].Value));

                rs.MoveNext();
            }

            rs.Close();

            return frequencies;
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

        public static Access.Dao.Recordset FindFirst(string tableName, string idField, int id)
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

        public static Access.Dao.Recordset NewRecord(string tableName)
        {
            Recordset rs = DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);

            rs.AddNew();

            return rs;
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

            // create tables
            Schemas.Income.CreateTable();
            Schemas.ExpenseCategory.CreateTable();
            Schemas.ExpenseFrequency.CreateTable();
            Schemas.Expense.CreateTable();


            // insert default data
            ExpenseCategory category = new ExpenseCategory();
            foreach (var value in new Tuple<string, string>[] {
                new Tuple<string, string>("Produse Alimentare", "pâine, lapte, ouă, ..."),
                new Tuple<string, string>("Sănătate", "analize medicale, medicamente, ..."),
                new Tuple<string, string>("Divertisment", "filme, masa la restaurant, ..."),
                new Tuple<string, string>("Servicii", "spălătorie, croitorie, ..."),
                new Tuple<string, string>("Pentru casă", "detergenți, mobilă, frigider, ..."),
                new Tuple<string, string>("Pentru mașină", "benzină, motorină, spălătorie, ..."),
                new Tuple<string, string>("Altele", "altele ..."),
                new Tuple<string, string>("Chirie", "..."),
                new Tuple<string, string>("Întreținere", "facturi la curent, gaze, ..."),
                new Tuple<string, string>("Abonamente", "netflix, internet, telefonie, ..."),
            })
            {
                category.Name = value.Item1;
                category.Description = value.Item2;
                category.Insert();
            }

            ExpenseFrequency frequency = new ExpenseFrequency();
            foreach (var value in new Tuple<string, int>[] {
                new Tuple<string, int>("Anual", 365),
                new Tuple<string, int>("Lunar", 30),
                new Tuple<string, int>("Zilnic", 1)
            })
            {
                frequency.Name = value.Item1;
                frequency.Days = value.Item2;
                frequency.Insert();
            }

            OnDatabaseCreated?.Invoke();
        }
        #endregion Private API
    }
}
