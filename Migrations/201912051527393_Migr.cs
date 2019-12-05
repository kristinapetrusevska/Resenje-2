namespace Resenje_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migr : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Exams(Grade,StudentId,CourseId) VALUES('4','5','7')");
        }
        
        public override void Down()
        {
        }
    }
}
