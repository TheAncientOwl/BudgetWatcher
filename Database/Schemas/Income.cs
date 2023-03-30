using Microsoft.Office.Interop.Access.Dao;
using System;

namespace BudgetDjinni.Database.Schemas
{
    public class Income : IDatabaseObject, IFormattable
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
        #endregion Properites

        #region Constructors
        public Income(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public Income() : this("Empty Income", 0) { }

        public Income(int id)
        {
            LoadFromId(id);
        }
        #endregion Constructors

        #region Public API
        public void LoadFromId(int id)
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Address with ID " + id + " matched");
            }

            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Value = (double)rs.Fields[Fields.Value].Value;

            rs.Close();
        }

        public void Save()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);

            rs.AddNew();
            Id = (int)rs.Fields[Fields.ID].Value;

            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Value].Value = Value;

            rs.Update();
            rs.Close();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("ID({0}) | Name({1}) | Value({2})", Id, Name, Value);
        }
        #endregion Public API
    }
}
