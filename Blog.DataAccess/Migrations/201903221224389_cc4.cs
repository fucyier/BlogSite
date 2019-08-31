namespace Blog.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cc4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Authors", "UserId");
            AddForeignKey("dbo.Authors", "UserId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "UserId", "dbo.Users");
            DropIndex("dbo.Authors", new[] { "UserId" });
            DropColumn("dbo.Authors", "UserId");
        }
    }
}
