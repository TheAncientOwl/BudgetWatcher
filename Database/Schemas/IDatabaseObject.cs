namespace BudgetDjinni.Database.Schemas
{
    public interface IDatabaseObject
    {
        void LoadFromId(int id);
        void Insert();
        void Update();
        void Delete();
    }
}
