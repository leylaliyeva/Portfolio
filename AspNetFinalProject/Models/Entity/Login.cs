using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class Login :BaseEntity
    {
        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        public string UserName { get; set; }


        public string Password { get; set; }
    }
}