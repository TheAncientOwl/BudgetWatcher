using System;

using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class Expense : IDatabaseObject
    {
        #region Database Config
        public static readonly string TableName = "Expenses";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Value = "Value";
            public static readonly string Date = "Date";
            public static readonly string CategoryId = "CategoryId";
            public static readonly string FrequencyId = "FrequencyId";
            public static readonly string Details = "Details";
        }
        #endregion Database Config

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public ExpenseCategory Category { get; set; }
        public ExpenseFrequency Frequency { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properties

        #region Constructors
        public Expense(string name, double value, DateTime date, string details, int categoryId, int frequencyId)
            => (Id, Name, Value, Date, Details, Category, Frequency) =
            (-1, name, value, date, details, 
            categoryId == -1 ? null : new ExpenseCategory(categoryId), 
            frequencyId == -1 ? null : new ExpenseFrequency(frequencyId));
        public Expense() : this("Empty Expense", 0, DateTime.Now, "-", -1, -1) { }
        public Expense(int id) => Manager.Instance.SelectFrom(TableName, id, this);
        #endregion Constructors

        #region Public API
        public void LoadFromRecordset(Recordset rs)
        {
            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Value = (double)rs.Fields[Fields.Value].Value;
            Date = (DateTime)rs.Fields[Fields.Date].Value;
            Details = (string)rs.Fields[Fields.Details].Value;
            Category = new ExpenseCategory((int)rs.Fields[Fields.CategoryId].Value);
            Frequency = new ExpenseFrequency((int)rs.Fields[Fields.FrequencyId].Value);
        }

        public void FillInRecordset(Recordset rs)
        {
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Value].Value = Value;
            rs.Fields[Fields.Date].Value = Date;
            rs.Fields[Fields.Details].Value = Details;
            rs.Fields[Fields.CategoryId].Value = Category.Id;
            rs.Fields[Fields.FrequencyId].Value = Frequency.Id;
        }

        public void Insert() => Manager.Instance.InsertInto(TableName, this);

        public void Update() => Manager.Instance.Update(TableName, this);

        public void Delete() => Manager.Instance.Delete(TableName, this);
        #endregion Public API
    }
}
