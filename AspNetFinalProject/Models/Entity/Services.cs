using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class Services :BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }


        public string Content { get; set; }

    }
}