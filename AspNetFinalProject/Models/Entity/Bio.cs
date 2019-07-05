using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class Bio : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}