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
        }
        #endregion Private API
    }
}
