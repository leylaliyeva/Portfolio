using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class Contact:BaseEntity
    {
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email  { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Message { get; set; }

        [ScaffoldColumn(false)]
        public bool IsRead { get; set; }
    }
}