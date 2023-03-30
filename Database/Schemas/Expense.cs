﻿using Microsoft.Office.Interop.Access.Dao;
using System;
using System.Collections.Generic;

namespace BudgetDjinni.Database.Schemas
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

        public static void CreateTable()
        {
            // create table definition
            TableDef tableDef = Manager.DbInstance.CreateTableDef(TableName);

            // create fields
            Field id = tableDef.CreateField(Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Fields.Name, DataTypeEnum.dbText);
            Field value = tableDef.CreateField(Fields.Value, DataTypeEnum.dbDouble);
            Field date = tableDef.CreateField(Fields.Date, DataTypeEnum.dbDate);
            Field categoryId = tableDef.CreateField(Fields.CategoryId, DataTypeEnum.dbLong);
            Field frequencyId = tableDef.CreateField(Fields.FrequencyId, DataTypeEnum.dbLong);
            Field details = tableDef.CreateField(Fields.Details, DataTypeEnum.dbMemo);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(value);
            tableDef.Fields.Append(date);
            tableDef.Fields.Append(categoryId);
            tableDef.Fields.Append(frequencyId);
            tableDef.Fields.Append(details);

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

            // define foreign key categoryId references ExpenseCategories.id
            categoryId.Required = true;

            Relation categoryRelation = Manager.DbInstance.CreateRelation();
            categoryRelation.Name = Expense.TableName + "_" + ExpenseCategory.TableName + "_ForeignKey";
            categoryRelation.Table = ExpenseCategory.TableName;
            categoryRelation.ForeignTable = Expense.TableName;
            categoryRelation.Attributes = (int)RelationAttributeEnum.dbRelationUpdateCascade | (int)RelationAttributeEnum.dbRelationDeleteCascade;

            Field fkCategoryField = categoryRelation.CreateField(ExpenseCategory.Fields.ID);
            fkCategoryField.ForeignName = Expense.Fields.CategoryId;
            categoryRelation.Fields.Append(fkCategoryField);

            Manager.DbInstance.Relations.Append(categoryRelation);

            // define foreign key frequencyId references ExpenseFrequencies.id
            frequencyId.Required = true;

            Relation frequencyRelation = Manager.DbInstance.CreateRelation();
            frequencyRelation.Name = Expense.TableName + "_" + ExpenseFrequency.TableName + "_ForeignKey";
            frequencyRelation.Table = ExpenseFrequency.TableName;
            frequencyRelation.ForeignTable = Expense.TableName;
            frequencyRelation.Attributes = (int)RelationAttributeEnum.dbRelationUpdateCascade | (int)RelationAttributeEnum.dbRelationDeleteCascade;

            Field fkFrequencyField = frequencyRelation.CreateField(ExpenseFrequency.Fields.ID);
            fkFrequencyField.ForeignName = Expense.Fields.FrequencyId;
            frequencyRelation.Fields.Append(fkFrequencyField);

            Manager.DbInstance.Relations.Append(frequencyRelation);
        }

        #endregion Database Table Definitions

        #region Properties
        public int Id { get; private set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public ExpenseCategory Category { get; set; }
        public ExpenseFrequency Frequency { get; set; }
        #endregion Properties

        #region Constructors
        public Expense(string name, double value, DateTime date, int categoryId, int frequencyId)
        {
            Id = -1;

            Name = name;
            Value = value;
            Date = date;

            Category = categoryId == -1 ? null : new ExpenseCategory(categoryId);
            Frequency = frequencyId == -1 ? null : new ExpenseFrequency(frequencyId);
        }

        public Expense() : this("Empty Expense", 0, DateTime.Now, -1, -1) { }

        public Expense(int id)
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
            Value = (double)rs.Fields[Fields.Value].Value;
            Date = (DateTime)rs.Fields[Fields.Date].Value;
            Category = new ExpenseCategory((int)rs.Fields[Fields.CategoryId].Value);
            Frequency = new ExpenseFrequency((int)rs.Fields[Fields.FrequencyId].Value);

            rs.Close();
        }

        public void Insert()
        {
            Recordset rs = Manager.NewRecord(TableName);

            Id = (int)rs.Fields[Fields.ID].Value;

            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Value].Value = Value;
            rs.Fields[Fields.Date].Value = Date;
            rs.Fields[Fields.CategoryId].Value = Category.Id;
            rs.Fields[Fields.FrequencyId].Value = Frequency.Id;

            rs.Update();
            rs.Close();
        }

        public void Update()
        {
            Recordset rs = Manager.FindFirst(TableName, Fields.ID, Id);

            rs.Edit();
            rs.Fields[Fields.Name].Value = Name;
            rs.Fields[Fields.Value].Value = Value;
            rs.Fields[Fields.Date].Value = Date;
            rs.Fields[Fields.CategoryId].Value = Category.Id;
            rs.Fields[Fields.FrequencyId].Value = Frequency.Id;

            rs.Update();
            rs.Close();
        }

        public void Delete()
        {
            Recordset rs = Manager.FindFirst(TableName, Fields.ID, Id);

            rs.Delete();

            rs.Close();
        }

        public bool Equals(Expense other) =>
            (Id == other.Id) && (Name == other.Name) && (Value == other.Value) && 
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
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpenseCategory>.Default.GetHashCode(Category);
            hashCode = hashCode * -1521134295 + EqualityComparer<ExpenseFrequency>.Default.GetHashCode(Frequency);
            return hashCode;
        }
        #endregion Public API
    }
}
