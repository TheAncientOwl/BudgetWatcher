using Microsoft.Office.Interop.Access.Dao;

using BudgetWatcher.Database.Schemas;
using System;
using BudgetWatcher.Forms;

namespace BudgetWatcher.Database
{
    public class TableIterator<DbObject> 
        : IDisposable
        where DbObject : IDatabaseObject, new()
    {
        #region Fields
        readonly Recordset m_Recordset = null;
        #endregion Fields

        #region Properties
        public DbObject Value
        {
            get
            {
                DbObject dbObject = new DbObject();
                dbObject.LoadFromRecordset(m_Recordset);

                return dbObject;
            }
        }
        #endregion Properties

        #region Constructors
        public TableIterator(string tableName)
        {
            m_Recordset = Manager.DbInstance.OpenRecordset(tableName, RecordsetTypeEnum.dbOpenDynaset);
        }
        #endregion Constructors

        #region Public API
        public dynamic GetField(string field) => m_Recordset.Fields[field].Value;

        public bool HasNext() => !m_Recordset.EOF;

        public void MoveNext() => m_Recordset.MoveNext();

        public void Reset() => m_Recordset.Requery();

        public void Dispose() => m_Recordset.Close();

        #endregion Public API
    }
}
