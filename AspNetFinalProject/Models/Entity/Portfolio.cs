using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class Portfolio:BaseEntity
    {
        public string MediaUrl { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}