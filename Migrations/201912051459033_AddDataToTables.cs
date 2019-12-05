namespace Resenje_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Courses(Name) VALUES('Matematika')");
            Sql("INSERT INTO Courses(Name) VALUES('Hemija')");
            Sql("INSERT INTO Courses(Name) VALUES('Fizika')");
            Sql("INSERT INTO Courses(Name) VALUES('Istorija')");
            Sql("INSERT INTO Courses(Name) VALUES('Geografija')");
            Sql("INSERT INTO Courses(Name) VALUES('Informatika')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Zoran','Zoric','Zoranova 1', 'Beograd')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Jovana','Jovic','Jovanova 2','Nis')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Goran','Goric','Goranova 1','Subotica')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Kristina','Mosic','Kristinova 4','Beograd')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Zorka','Zokic','Zoranova 4','Nis')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Jagoda','Jagodic','Jagodova 1','Jagodina')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Milan','Milanovic','Milanova 4','Beograd')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Zeljko','Josic','Zeljkova 19','Nis')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Goran','Tomovic','Toma 18','Nis')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Ivan','Ivanic','Ivanova 6','Jagodina')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Goca','Djukic','Gocova 8','Leskovac')");
            Sql("INSERT INTO Students(Name,Surname,Address,Town) VALUES('Zagorka','Zagorkic','Zagorova 3','Leskovac')");
            
        }
        
        public override void Down()
        {
        }
    }
}
