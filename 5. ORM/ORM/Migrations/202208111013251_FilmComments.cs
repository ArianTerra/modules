namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FilmComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Emote = c.Byte(nullable: false),
                        Rating = c.Byte(nullable: false),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Film_Id", "dbo.Films");
            DropIndex("dbo.Comments", new[] { "Film_Id" });
            DropTable("dbo.Comments");
        }
    }
}
