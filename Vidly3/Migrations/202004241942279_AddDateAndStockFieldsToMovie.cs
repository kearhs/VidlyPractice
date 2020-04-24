namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndStockFieldsToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Movies", "NumberOfStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberOfStock");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
