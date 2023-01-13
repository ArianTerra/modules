namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActorComments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Actor_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Actor_Id");
            AddForeignKey("dbo.Comments", "Actor_Id", "dbo.Actors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.Comments", new[] { "Actor_Id" });
            DropColumn("dbo.Comments", "Actor_Id");
        }
    }
}
