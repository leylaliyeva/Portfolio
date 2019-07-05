using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class AcademicBackground : BaseEntity
    {
        public int BeginDate { get; set; }
        public int GraduateDate { get; set; }
        public string Title { get; set; }
        public string Faculty { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}