namespace Veterinaria.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Owners", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Owners", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Owners", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Owners", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
