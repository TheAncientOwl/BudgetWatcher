using Microsoft.Office.Interop.Access.Dao;

using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Database
{
    public class TableIterator<DbObject> where DbObject : IDatabaseObject, new()
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

        public void Close() => m_Recordset.Close();

        public bool HasNext() => !m_Recordset.EOF;

        public void MoveNext() => m_Recordset.MoveNext();

        public void Reset() => m_Recordset.Requery();
        #endregion Public API
    }
}
