using Microsoft.Office.Interop.Access.Dao;

namespace BudgetDjinni.Database.Schemas
{
    public class ExpenseCategory
    {
        #region Database Table Definitions
        public static readonly string TableName = "ExpenseCategories";

        public static class Fields
        {
            public static readonly string ID = "ID";
            public static readonly string Name = "Name";
            public static readonly string Description = "Description";
        }

        public static void CreateTable()
        {
            // create table definition
            TableDef tableDef = Manager.DbInstance.CreateTableDef(TableName);

            // create fields
            Field id = tableDef.CreateField(Fields.ID, DataTypeEnum.dbLong);
            Field name = tableDef.CreateField(Fields.Name, DataTypeEnum.dbText);
            Field description = tableDef.CreateField(Fields.Description, DataTypeEnum.dbText);

            // append fields
            tableDef.Fields.Append(id);
            tableDef.Fields.Append(name);
            tableDef.Fields.Append(description);

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
    }
}
