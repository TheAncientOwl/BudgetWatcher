namespace BudgetDjinni.Database.Schemas
{
    public interface IDatabaseObject
    {
        void LoadFromId(int id);
        void Save();
        void Update();
        void Delete();
    }
}
