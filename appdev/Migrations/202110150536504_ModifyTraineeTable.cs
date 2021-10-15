namespace appdev.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTraineeTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TraineeUsers", new[] { "Trainees_Id" });
            DropColumn("dbo.TraineeUsers", "TraineeID");
            RenameColumn(table: "dbo.TraineeUsers", name: "Trainees_Id", newName: "TraineeId");
            DropPrimaryKey("dbo.TraineeUsers");
            AddColumn("dbo.TraineeUsers", "FullName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TraineeUsers", "TraineeId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TraineeUsers", "Age", c => c.Int(nullable: false));
            AlterColumn("dbo.TraineeUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TraineeUsers", "Education", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.TraineeUsers", "TraineeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.TraineeUsers", "TraineeId");
            CreateIndex("dbo.TraineeUsers", "TraineeId");
            DropColumn("dbo.TraineeUsers", "ID");
            DropColumn("dbo.TraineeUsers", "Full_Name");
            DropColumn("dbo.TraineeUsers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TraineeUsers", "Email", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "Full_Name", c => c.String(maxLength: 255));
            AddColumn("dbo.TraineeUsers", "ID", c => c.Int(nullable: false, identity: true));
            DropIndex("dbo.TraineeUsers", new[] { "TraineeId" });
            DropPrimaryKey("dbo.TraineeUsers");
            AlterColumn("dbo.TraineeUsers", "TraineeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.TraineeUsers", "Education", c => c.String(maxLength: 255));
            AlterColumn("dbo.TraineeUsers", "DateOfBirth", c => c.String(maxLength: 255));
            AlterColumn("dbo.TraineeUsers", "Age", c => c.String(maxLength: 255));
            AlterColumn("dbo.TraineeUsers", "TraineeId", c => c.String(nullable: false));
            DropColumn("dbo.TraineeUsers", "FullName");
            AddPrimaryKey("dbo.TraineeUsers", "ID");
            RenameColumn(table: "dbo.TraineeUsers", name: "TraineeId", newName: "Trainees_Id");
            AddColumn("dbo.TraineeUsers", "TraineeID", c => c.String(nullable: false));
            CreateIndex("dbo.TraineeUsers", "Trainees_Id");
        }
    }
}
