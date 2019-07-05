using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.ViewModel
{
    public class AboutMeViewModel
    {
        public AboutMe About { get; set; }
        public Bio Bio { get; set; }
        public IEnumerable<Services> Services { get; set; }
        public List<Skills> Skills { get; set; }
    }
}