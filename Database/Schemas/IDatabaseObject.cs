using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public interface IDatabaseObject
    {
        int ID { get; }
        string IdProperty { get; }
        string IdTableField { get; }

        void LoadFromRecordset(Recordset rs);
        void FillInRecordset(Recordset rs);

        void Insert();
        void Update();
        void Delete();
    }
}
