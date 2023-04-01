using System;
using System.Collections.Generic;

using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class ExpenseFrequency : IDatabaseObject, IEquatable<ExpenseFrequency>
    {
        #region Database Table Definitions
        public static readonly string TableName = "ExpenseFrequencies";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Days = "Days";
        }
        #endregion Database Table Definitions

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Days { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properties

        #region Constructors
        public ExpenseFrequency(string name, int days)
        {
            Id = -1;
            Name = name;
            Days = days;
        }

        public ExpenseFrequency() : this("Empty Frequency", 1) { }

        public ExpenseFrequency(int id)
        {
            Manager.Instance.SelectFrom(TableName, id, this);
        }

        public ExpenseFrequency(Recordset rs)
        {
            LoadFromRecordset(rs);
        }
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

        public bool Equals(ExpenseFrequency other) => (Id == other.Id) && (Name == other.Name) && (Days == other.Days);
        public override bool Equals(object obj) => Equals(obj as ExpenseFrequency);

        public override int GetHashCode()
        {
            int hashCode = 1671770016;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Days.GetHashCode();
            return hashCode;
        }
        #endregion Public API
    }
}
