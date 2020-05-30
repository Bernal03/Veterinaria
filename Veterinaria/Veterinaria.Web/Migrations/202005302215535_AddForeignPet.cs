namespace Veterinaria.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignPet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners");
            DropIndex("dbo.Pets", new[] { "Owner_Id" });
            RenameColumn(table: "dbo.Pets", name: "Owner_Id", newName: "OwnerId");
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Pets", "OwnerId");
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.Owners", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Owners");
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int());
            RenameColumn(table: "dbo.Pets", name: "OwnerId", newName: "Owner_Id");
            CreateIndex("dbo.Pets", "Owner_Id");
            AddForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners", "Id");
        }
    }
}
