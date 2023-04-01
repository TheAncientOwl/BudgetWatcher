using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class ExpenseFrequency : IDatabaseObject
    {
        #region Database Config
        public static readonly string TableName = "ExpenseFrequencies";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Days = "Days";
        }
        #endregion Database Config

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Days { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properties

        #region Constructors
        public ExpenseFrequency(string name, int days) => (Id, Name, Days) = (-1, name, days);
        public ExpenseFrequency() : this("Empty Frequency", 1) { }
        public ExpenseFrequency(int id) => Manager.Instance.SelectFrom(TableName, id, this);
        #endregion Constructors

        #region Public API
        public void LoadFromRecordset(Recordset rs)
        {
            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Days = (int)rs.Fields[Fields.Days].Value;
        }

        public void FillInRecordset(Recordset rs)
        {
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Days].Value = Days;
        }

        public void Insert() => Manager.Instance.InsertInto(TableName, this);

        public void Update() => Manager.Instance.Update(TableName, this);

        public void Delete() => Manager.Instance.Delete(TableName, this);
        #endregion Public API
    }
}
