using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetFinalProject.Models.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [ResumeDatabaseGenerated(DatabaseGeneratedOption.Computed,DefaultValueSql = "getdate()")]
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; }
    }
}