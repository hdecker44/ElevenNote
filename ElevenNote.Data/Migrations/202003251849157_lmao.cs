namespace ElevenNote.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lmao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Note", "CategoryId", "dbo.Category");
            DropIndex("dbo.Note", new[] { "CategoryId" });
            DropColumn("dbo.Note", "CategoryId");
            DropTable("dbo.Category");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Note", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Note", "CategoryId");
            AddForeignKey("dbo.Note", "CategoryId", "dbo.Category", "Id", cascadeDelete: true);
        }
    }
}
