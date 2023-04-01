namespace BudgetWatcher.Database.Schemas
{
    public interface IDatabaseObjectFiller<DbObject> where DbObject : IDatabaseObject
    {
        void FillInData(DbObject dbObject);
    }
}
