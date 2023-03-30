using Microsoft.Office.Interop.Access.Dao;
using System;
using System.Collections.Generic;

namespace BudgetDjinni.Database.Schemas
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

        public static void CreateTable()
        {
            // create table definition
            TableDef tableDef = Manager.DbInstance.CreateTableDef(TableName);

            // create fields
            Field id = tableDef.CreateField(Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Fields.Name, DataTypeEnum.dbText);
            Field days = tableDef.CreateField(Fields.Days, DataTypeEnum.dbInteger);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(days);

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

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Days { get; set; }
        #endregion Properties

        #region Constructors
        public ExpenseFrequency(string name, int days)
        {
            Id = -1;
            Name = name;
            Days = days;
        }

        public ExpenseFrequency() : this("Empty Frequency", 0) { }

        public ExpenseFrequency(int id)
        {
            LoadFromId(id);
        }
        #endregion Constructors

        #region Public API
        public void LoadFromId(int id)
        {
            Recordset rs = Manager.FindFirst(TableName, Fields.ID, id);

            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Days = (int)rs.Fields[Fields.Days].Value;

            rs.Close();
        }

        public void Insert()
        {
            Recordset rs = Manager.NewRecord(TableName);

            Id = (int)rs.Fields[Fields.ID].Value;

            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Days].Value = Days;

            rs.Update();
            rs.Close();
        }

        public void Update()
        {
            Recordset rs = Manager.FindFirst(TableName, Fields.ID, Id);

            rs.Edit();
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Days].Value = Days;

            rs.Update();
            rs.Close();
        }

        public void Delete()
        {
            Recordset rs = Manager.FindFirst(TableName, Fields.ID, Id);

            rs.Delete();

            rs.Close();
        }

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
