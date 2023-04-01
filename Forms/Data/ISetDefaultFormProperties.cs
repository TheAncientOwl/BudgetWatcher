using BudgetWatcher.Database.Schemas;

namespace BudgetWatcher.Forms.Data
{
    public interface ISetDefaultFormProperties<DbObject> where DbObject : IDatabaseObject
    {
        void SetDefaultFormProperties(string formTitle, DbObject defaultDbObject);
    }
}
