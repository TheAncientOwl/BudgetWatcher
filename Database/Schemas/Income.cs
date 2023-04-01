using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class Income : IDatabaseObject
    {
        #region Database Config
        public static readonly string TableName = "Incomes";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Value = "Value";
        }
        #endregion Database Config

        #region Properites
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properites

        #region Constructors
        public Income(string name, double value) => (Id, Name, Value) = (-1, name, value);
        public Income() : this("Empty Income", 0) { }
        public Income(int id) => Manager.Instance.SelectFrom(TableName, id, this);
        #endregion Constructors

        #region Public API
        public void LoadFromRecordset(Recordset rs)
        {
            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Value = (double)rs.Fields[Fields.Value].Value;
        }

        public void FillInRecordset(Recordset rs)
        {
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Value].Value = Value;
        }

        public void Insert() => Manager.Instance.InsertInto(TableName, this);

        public void Update() => Manager.Instance.Update(TableName, this);

        public void Delete() => Manager.Instance.Delete(TableName, this);
        #endregion Public API
    }
}
