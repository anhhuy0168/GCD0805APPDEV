namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTraineeUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TraineeUsers", "TraineeID", c => c.String(nullable: false));
            AddColumn("dbo.TraineeUsers", "DateOfBirth", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "Education", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "Trainees_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.TraineeUsers", "Age", c => c.String(maxLength: 255));
            CreateIndex("dbo.TraineeUsers", "Trainees_Id");
            AddForeignKey("dbo.TraineeUsers", "Trainees_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.TraineeUsers", "TrainerID");
            DropColumn("dbo.TraineeUsers", "Specialty");
            DropColumn("dbo.TraineeUsers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeUsers", "Address", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "Specialty", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "TrainerID", c => c.String(nullable: false));
            DropForeignKey("dbo.TraineeUsers", "Trainees_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TraineeUsers", new[] { "Trainees_Id" });
            AlterColumn("dbo.TraineeUsers", "Age", c => c.String());
            DropColumn("dbo.TraineeUsers", "Trainees_Id");
            DropColumn("dbo.TraineeUsers", "Education");
            DropColumn("dbo.TraineeUsers", "DateOfBirth");
            DropColumn("dbo.TraineeUsers", "TraineeID");
        }
    }
}
