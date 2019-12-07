namespace Resenje_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Surname", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Surname", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Name", c => c.String(maxLength: 20));
        }
    }
}
