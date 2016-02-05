namespace MosaicoMailEditor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailMessageTemplates",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Html = c.String(),
                        Metadata = c.String(),
                        Template = c.String(),
                    })
                .PrimaryKey(t => t.Key);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MailMessageTemplates");
        }
    }
}
