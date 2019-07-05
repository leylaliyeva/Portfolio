using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace AspNetFinalProject
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple =false)]
    public class ResumeDatabaseGeneratedAttribute:DatabaseGeneratedAttribute
    {
        public string DefaultValueSql { get; set; }
        public ResumeDatabaseGeneratedAttribute(DatabaseGeneratedOption databaseGeneratedOption)
            : base(databaseGeneratedOption)
        {

        }
    }
}