using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public class AboutMe : BaseEntity
    {
        [DisplayName("Image")]
        public string MediaUrl { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        [MaxLength(50)]
        public  string Location { get; set; }

        [Required]
        public byte Experience  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Degree { get; set; }

        [Required]
        [MaxLength(50)]
        public string CareerLevel { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }


        [Required]
        [MaxLength(50)]
        public string Fax { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Website { get; set; }

        public virtual IEnumerable<AcademicBackground> AcademicBackgrounds { get; set; }
        public virtual IEnumerable<ProffesionalExperience> ProffesionalExperiences { get; set; }
        public virtual  List<Skills> Skills { get; set; }
        public virtual IEnumerable<Services> Services { get; set; }
        public virtual Bio Bio  { get; set; }
        public virtual Portfolio Portfolio { get; set; }
        public virtual Blog Blog { get; set; }
    }
}