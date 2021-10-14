namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTrainee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TraineeUsers", "Trainers_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TraineeUsers", new[] { "Trainers_Id" });
            DropColumn("dbo.TraineeUsers", "Trainers_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeUsers", "Trainers_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TraineeUsers", "Trainers_Id");
            AddForeignKey("dbo.TraineeUsers", "Trainers_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
