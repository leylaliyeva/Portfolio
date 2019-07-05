using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models.Entity
{
    public enum HardSoft
    {
        HardSkill,
        SoftSkill
    }
    public class Skills : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public byte Percent { get; set; }

        public string Description { get; set; }

       
        public HardSoft SkillType { get; set; }
    }
}