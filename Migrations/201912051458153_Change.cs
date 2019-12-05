namespace Resenje_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Name", c => c.String(maxLength: 20));
            AddColumn("dbo.Students", "Surname", c => c.String(maxLength: 20));
            AddColumn("dbo.Students", "Address", c => c.String(maxLength: 25));
            AddColumn("dbo.Students", "Town", c => c.String(maxLength: 20));
            DropColumn("dbo.Students", "Ime");
            DropColumn("dbo.Students", "Prezime");
            DropColumn("dbo.Students", "Adresa");
            DropColumn("dbo.Students", "Grad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Grad", c => c.String(maxLength: 20));
            AddColumn("dbo.Students", "Adresa", c => c.String(maxLength: 25));
            AddColumn("dbo.Students", "Prezime", c => c.String(maxLength: 20));
            AddColumn("dbo.Students", "Ime", c => c.String(maxLength: 20));
            DropColumn("dbo.Students", "Town");
            DropColumn("dbo.Students", "Address");
            DropColumn("dbo.Students", "Surname");
            DropColumn("dbo.Students", "Name");
        }
    }
}
