using Microsoft.Office.Interop.Access.Dao;
using System;

namespace BudgetDjinni.Database.Schemas
{
    public class ExpenseFrequency : IDatabaseObject, IFormattable
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
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Frequency with ID " + id + " matched");
            }

            Id = (int)rs.Fields[Fields.ID].Value;
            Name = (string)rs.Fields[Fields.Name].Value;
            Days = (int)rs.Fields[Fields.Days].Value;

            rs.Close();
        }

        public void Save()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);

            rs.AddNew();
            Id = (int)rs.Fields[Fields.ID].Value;

            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Days].Value = Days;

            rs.Update();
            rs.Close();
        }

        public void Update()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + Id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Frequency with ID " + Id + " matched");
            }

            rs.Edit();
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Days].Value = Days;

            rs.Update();
            rs.Close();
        }

        public void Delete()
        {
            Recordset rs = Manager.DbInstance.OpenRecordset(TableName, RecordsetTypeEnum.dbOpenDynaset);
            rs.FindFirst(Fields.ID + " = " + Id);

            if (rs.NoMatch)
            {
                rs.Close();
                throw new Exception("No Frequency with ID " + Id + " matched");
            }

            rs.Delete();

            rs.Close();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format("ID({0}) Name({1}) Days({2})", Id, Name, Days);
        }
        #endregion Public API
    }
}
