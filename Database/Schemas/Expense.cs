using Microsoft.Office.Interop.Access.Dao;
using System;

namespace BudgetDjinni.Database.Schemas
{
//ID  int
//Denumire    string
//Valoare float
//Data    DateTime
//Categorie   CategorieCheltuieli
//Frecvență   FrecvențăCheltuieli
//Detalii string

    public class Expense
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
    }
}
