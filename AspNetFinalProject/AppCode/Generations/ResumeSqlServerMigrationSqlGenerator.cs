using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace AspNetFinalProject
{
    public class ResumeSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(AddColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterColumnOperation operation)
        {
            SetColumnValue(operation.Column);

            base.Generate(operation);
        }

        protected override void Generate(AlterTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        protected override void Generate(CreateTableOperation operation)
        {
            foreach (var column in operation.Columns)
                SetColumnValue(column);

            base.Generate(operation);
        }

        void SetColumnValue(ColumnModel column)
        {
            if (column.Annotations.TryGetValue("ResumeDatabaseGeneratedAttribute", out AnnotationValues ResumeDatabaseValue))
            {
                column.DefaultValueSql = (ResumeDatabaseValue.NewValue ?? "").ToString();
            }
            else if (column.Annotations.TryGetValue("ResumeSqlDefaultValueAttribute", out AnnotationValues ResumeSqlDefaultValue))
            {
                column.DefaultValueSql = (ResumeSqlDefaultValue.NewValue ?? "").ToString();
            }
        }

        //private static void SetCreatedDateColumn(PropertyModel column)
        //{
        //    if (column.Name == "CreatedDate")
        //    {
        //        column.DefaultValueSql = "getdate()";
        //    }
        //}
    }
}