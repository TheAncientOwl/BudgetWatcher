using BudgetWatcher.Database.Schemas;
using Microsoft.Office.Interop.Access.Dao;
using System;
using System.IO;
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

        #region Public API
        public void OpenOrCreateDatabase()
        {
            if (m_AccessApp != null) return;

            m_AccessApp = new Access.Application();

            if (File.Exists(DatabaseFilePath))
            {
                OpenDatabase();
            }
            else
            {
                CreateDatabase();
            }
        }

        public void CloseDatabase()
        {
            if (m_AccessApp == null) return;

            m_AccessApp.CloseCurrentDatabase();
            m_AccessApp.Quit();
            m_AccessApp = null;
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
            m_AccessApp.OpenCurrentDatabase(DatabaseFilePath);
        }

        void CreateDatabase()
        {
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
        }
        #endregion Private API
    }
}
