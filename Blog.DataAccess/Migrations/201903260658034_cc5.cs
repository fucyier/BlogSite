namespace Blog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsFeatured", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsFeatured");
        }
    }
}
