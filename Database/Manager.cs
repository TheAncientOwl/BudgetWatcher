using Microsoft.Office.Interop.Access.Dao;
using System;
using System.IO;
using Access = Microsoft.Office.Interop.Access;

namespace BudgetDjinni.Database
{
    public class Manager
    {
        #region Fields
        public static readonly string DatabaseFilePath = Path.Combine(AppContext.BaseDirectory, "BudgetDjinni.accdb");
        static Manager s_Instance = new Manager();

        Access.Application m_AccessApp = null;
        #endregion Fields

        #region Properties
        public static Manager Instance { get => s_Instance; }
        public static Access.Dao.Database DbInstance { get => Instance.m_AccessApp.CurrentDb(); }
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
        }
        #endregion Private API
    }
}
