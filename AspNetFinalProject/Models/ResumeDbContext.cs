using AspNetFinalProject.Migrations;
using AspNetFinalProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AspNetFinalProject.Models
{
    public class ResumeDbContext : DbContext
    {

        public ResumeDbContext()
            : base("name=cString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ResumeDbContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Add(new AttributeToColumnAnnotationConvention<ResumeDatabaseGeneratedAttribute,string>("ResumeDatabaseGeneratedAttribute",(p,attr)=> attr.Single().DefaultValueSql));
            //builder.Conventions.Add(new AttributeToColumnAnnotationConvention<ResumeDefaultValueSqlAttribute,string>("ResumeDefaultValueSqlAttribute", (p,attr)=> attr.Single().DefaultValueSql));


            base.OnModelCreating(builder);
        }

        public DbSet<AboutMe> AboutMe { get; set; }
        public DbSet<AcademicBackground> AcademicBackGround { get; set; }
        public DbSet<Bio> Bio { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<ProffesionalExperience> ProffesionalExperience { get; set; }
        public DbSet<Services> Service { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}