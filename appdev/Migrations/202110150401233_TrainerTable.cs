namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrainerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainerUsers",
                c => new
                    {
                        TrainerId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false, maxLength: 30),
                        Age = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Specialty = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.TrainerId)
                .ForeignKey("dbo.AspNetUsers", t => t.TrainerId)
                .Index(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainerUsers", "TrainerId", "dbo.AspNetUsers");
            DropIndex("dbo.TrainerUsers", new[] { "TrainerId" });
            DropTable("dbo.TrainerUsers");
        }
    }
}
