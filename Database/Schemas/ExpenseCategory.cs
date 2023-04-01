using System;
using System.Collections.Generic;

using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class ExpenseCategory : IDatabaseObject, IEquatable<ExpenseCategory>
    {
        #region Database Config
        public static readonly string TableName = "ExpenseCategories";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Description = "Description";
        }
        #endregion Database Config

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properties

        #region Constructors
        public ExpenseCategory(string name, string description)
        {
            Id = -1;
            Name = name;
            Description = description;
        }

        public ExpenseCategory() : this("Empty Category", "-") { }

        public ExpenseCategory(int id)
        {
            Manager.Instance.SelectFrom(TableName, id, this);
        }

        public ExpenseCategory(Recordset rs)
        {
            LoadFromRecordset(rs);
        }
        #endregion Constructors

        #region Public API
        public void LoadFromRecordset(Recordset rs)
        {
            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Description = (string)rs.Fields[Fields.Description].Value;
        }

        public void FillInRecordset(Recordset rs)
        {
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Description].Value = Description;
        }

        public void Insert() => Manager.Instance.InsertInto(TableName, this);

        public void Update() => Manager.Instance.Update(TableName, this);

        public void Delete() => Manager.Instance.Delete(TableName, this);

        public bool Equals(ExpenseCategory other) => (Id == other.Id) && (Name == other.Name) && (Description == other.Description);
        public override bool Equals(object obj) => Equals(obj as ExpenseCategory);

        public override int GetHashCode()
        {
            int hashCode = 1829809407;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            return hashCode;
        }
        #endregion Public API
    }
}
