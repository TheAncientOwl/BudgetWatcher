using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public interface IDatabaseObject
    {
        void LoadFromRecordset(Recordset rs);
        void FillInRecordset(Recordset rs);
        void LoadFromId(int id);
        void Insert();
        void Update();
        void Delete();
    }
}
