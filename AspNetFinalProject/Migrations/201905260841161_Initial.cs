namespace AspNetFinalProject.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AboutMes", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.Bios", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.Blogs", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.Portfolios", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.Skills", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.AcademicBackgrounds", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.ProffesionalExperiences", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
            AlterColumn("dbo.Services", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: null, newValue: "getdate()")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.ProffesionalExperiences", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.AcademicBackgrounds", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Skills", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Portfolios", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Blogs", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Bios", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
            AlterColumn("dbo.AboutMes", "CreatedDate", c => c.DateTime(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "ResumeDatabaseGeneratedAttribute",
                        new AnnotationValues(oldValue: "getdate()", newValue: null)
                    },
                }));
        }
    }
}
