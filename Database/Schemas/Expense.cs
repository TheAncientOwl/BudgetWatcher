using System;
using System.Collections.Generic;

using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class Expense : IDatabaseObject, IEquatable<Expense>
    {
        #region Database Table Definitions
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
        #endregion Database Table Definitions

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
        {
            Id = -1;

            Name = name;
            Value = value;
            Date = date;
            Details = details;

            Category = categoryId == -1 ? null : new ExpenseCategory(categoryId);
            Frequency = frequencyId == -1 ? null : new ExpenseFrequency(frequencyId);
        }

        public Expense() : this("Empty Expense", 0, DateTime.Now, "-", -1, -1) { }

        public Expense(int id)
        {
            Manager.Instance.SelectFrom(TableName, id, this);
        }
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

        public bool Equals(Expense other) =>
            (Id == other.Id) && (Name == other.Name) && (Value == other.Value) && (Details == other.Details) &&
            (Date.Day == other.Date.Day) && (Date.Month == other.Date.Month) && (Date.Year == other.Date.Year) &&
            (Category.Equals(other.Category)) && (Frequency.Equals(other.Frequency));
        public override bool Equals(object obj) => Equals(obj as Expense);

        public override int GetHashCode()
        {
            int hashCode = 1342306499;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Details);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpenseCategory>.Default.GetHashCode(Category);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpenseFrequency>.Default.GetHashCode(Frequency);
            return hashCode;
        }
        #endregion Public API
    }
}
