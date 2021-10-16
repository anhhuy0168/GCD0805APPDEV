namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTraineeToCourseTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TraineesToCourses",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TraineeId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.TraineeUsers", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TraineesToCourses", "TraineeId", "dbo.TraineeUsers");
            DropForeignKey("dbo.TraineesToCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.TraineesToCourses", new[] { "CourseId" });
            DropIndex("dbo.TraineesToCourses", new[] { "TraineeId" });
            DropTable("dbo.TraineesToCourses");
        }
    }
}
