using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.ViewModel
{
    public class ResumeViewModel
    {
        public Bio Bio { get; set; }
        public List<Skills> Skills { get; set; }
        public List<ProffesionalExperience> ProffesionalExperiences { get; set; }
        public List<AcademicBackground> AcademicBackgrounds { get; set; }
    }
}