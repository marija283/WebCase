namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attachment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cases", "attachment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cases", "attachment");
        }
    }
}
