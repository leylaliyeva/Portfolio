using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class ProffesionalExperience : BaseEntity
    {
        public int BeginDate { get; set; }
        public int GraduateDate { get; set; }
        public string Title { get; set; }
        public string  Job { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}