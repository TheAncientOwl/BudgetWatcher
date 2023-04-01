using System;
using System.Collections.Generic;

using Microsoft.Office.Interop.Access.Dao;

namespace BudgetWatcher.Database.Schemas
{
    public class Income : IDatabaseObject, IEquatable<Income>
    {
        #region Database Table Definitions
        public static readonly string TableName = "Incomes";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Value = "Value";
        }

        public static void CreateTable()
        {
            // create table definition
            TableDef tableDef = Manager.DbInstance.CreateTableDef(TableName);

            // create fields
            Field id = tableDef.CreateField(Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Fields.Name, DataTypeEnum.dbText);
            Field value = tableDef.CreateField(Fields.Value, DataTypeEnum.dbDouble);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(value);

            // define primary key on id
            id.Attributes = (int)FieldAttributeEnum.dbAutoIncrField;
            id.Required = true;

            Index primaryKeyIndex = tableDef.CreateIndex(TableName + "_PrimaryKey");
            primaryKeyIndex.Primary = true;
            primaryKeyIndex.Unique = true;
            primaryKeyIndex.Fields.Append(primaryKeyIndex.CreateField(Fields.ID));
            tableDef.Indexes.Append(primaryKeyIndex);

            // add table definition
            Manager.DbInstance.TableDefs.Append(tableDef);
        }

        #endregion Database Table Definitions

        #region Properites
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public int ID => Id;
        public string IdProperty => "Id";
        public string IdTableField => Fields.ID;
        #endregion Properites

        #region Constructors
        public Income(string name, double value)
        {
            Id = -1;
            Name = name;
            Value = value;
        }

        public Income() : this("Empty Income", 0) { }

        public Income(int id)
        {
            Manager.Instance.SelectFrom(TableName, id, this);
        }

        public Income(Recordset recordSet)
        {
            LoadFromRecordset(recordSet);
        }
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

        public bool Equals(Income other) => (Id == other.Id) && (Name == other.Name) && (Value == other.Value);
        public override bool Equals(object obj) => Equals(obj as Income);

        public override int GetHashCode()
        {
            int hashCode = -679859104;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Value.GetHashCode();
            return hashCode;
        }
        #endregion Public API
    }
}
