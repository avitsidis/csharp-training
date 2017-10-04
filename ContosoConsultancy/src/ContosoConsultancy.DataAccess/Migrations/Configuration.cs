namespace ContosoConsultancy.DataAccess.Migrations
{
    using ContosoConsultancy.Core.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ContosoConsultancy.DataAccess.ContosoConsultancyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContosoConsultancyDataContext context)
        {
            #region customers
            var customer1 = new Customer
            {
                Id = 1,
                Name = "Royal Felin",
                Address = new Address {Country="BE", City = "Namur", PostCode = "1000", Street = "Rue des félidés", Number = "42" },
            };
            var customer2 = new Customer
            {
                Id = 2,
                Name = "Coke-a-Kohla",
                Address = new Address {Country="LU", City = "Brussels", PostCode = "1000", Street = "Rue des brasseurs", Number = "69" }
            };
            var customer3 = new Customer
            {
                Id = 3,
                Name = "L'or et Al",
                Address = new Address { Country = "BE", City = "Brussels", PostCode = "1000", Street = "kapperstraat", Number = "666" }
            };
            var customer4 = new Customer
            {
                Id = 4,
                Name = "Colreuitte",
                Address = new Address { Country = "BE",City="Brussels",PostCode="1000",Street="WinkelStraat",Number="1" }
            };
            var customer5 = new Customer
            {
                Id = 5,
                Name = "Banque La Magouille",
                Address = new Address { Country = "LU", City = "Luxembourg", Street = "Rue des banquiers", Number = "12", PostCode = "L-1000" }
            };
            var customer6 = new Customer
            {
                Id = 6,
                Name = "XAX Bank",
                Address = new Address { Country = "LU", City = "Luxembourg", Street = "Rue des banquiers", Number = "13", PostCode = "L-1000" }
            };
            #endregion
            #region competencies
            var dotnet = new Competency { Id = 1, Name = ".Net" };
            var java = new Competency { Id = 2, Name = "java" };
            var sql = new Competency { Id = 4, Name = "sql" };
            var bo = new Competency { Id = 4, Name = "Business Object" };
            var cobol = new Competency { Id = 5, Name = "Cobol" };
            var linq = new Competency { Id = 6, Name = "linq" };
            var spring = new Competency { Id = 7, Name = "Spring" };
            var reporting = new Competency { Id = 8, Name = "reporting" };
            var js = new Competency { Id = 9, Name = "javascript" };
            var ng = new Competency { Id = 10, Name = "Angular" };
            #endregion

            #region consultants
            var consultant1 = new Consultant(1, "Philip", "Easter", new DateTime(1970, 12, 6), new DateTime(1988, 1, 1));
            var consultant2 = new Consultant(2, "Peter", "Cita", new DateTime(1975, 5, 5), new DateTime(1995, 1, 1));
            var consultant3 = new Consultant(3, "Marco", "Zuckerbergio", new DateTime(1980, 4, 15), new DateTime(2000, 1, 1))
            {
                DisengagedDate = new DateTime(2004, 12, 31)
            };
            var consultant4 = new Consultant(4, "Tronald", "Dumb", new DateTime(1970, 3, 25), new DateTime(1992, 1, 1))
            {
                DisengagedDate = new DateTime(1999, 4, 1)
            };
            var consultant5 = new Consultant(5, "Vlad", "Poutinne", new DateTime(1970, 2, 27), new DateTime(1992, 1, 1))
            {
                DisengagedDate = new DateTime(1999, 4, 1)
            };
            var consultant6 = new Consultant(6, "Dany", "Stormborn", new DateTime(1990, 2, 16), new DateTime(2012, 1, 1));
            var consultant7 = new Consultant(7, "Lanny", "Ster", new DateTime(1986, 6, 15), new DateTime(2009, 1, 1));
            var consultant8 = new Consultant(8, "Johnny", "Snowy", new DateTime(1988, 9, 1), new DateTime(2011, 1, 1));
            var consultant9 = new Consultant(9, "Lara", "Joygrey", new DateTime(1991, 9, 27), new DateTime(2013, 1, 1));
            var consultant10 = new Consultant(10, "Theon", "Barra", new DateTime(1992, 8, 25), new DateTime(2014, 1, 1));
            var consultant11 = new Consultant(11, "Robby", "Starsky", new DateTime(1979, 7, 5), new DateTime(2008, 1, 1));
            var consultant12 = new Consultant(12, "Satya", "Nutella", new DateTime(1980, 3, 26), new DateTime(2008, 1, 1));
            var consultant13 = new Consultant(13, "John", "Doe", new DateTime(1974, 5, 5), new DateTime(1998, 1, 1));
            var consultant14 = new Consultant(14, "Foo", "Bar", new DateTime(1978, 2, 5), new DateTime(1998, 1, 1));
            var consultant15 = new Consultant(15, "Alice", "Pass", new DateTime(1990, 10, 2), new DateTime(2012, 1, 1));
            var consultant16 = new Consultant(16, "Bob", "Word", new DateTime(1991, 11, 8), new DateTime(2013, 1, 1));
            var consultant17 = new Consultant(17, "Kara", "Doque", new DateTime(1985, 4, 2), new DateTime(2007, 1, 1))
            {
                DisengagedDate = new DateTime(2015, 12, 31)
            };
            var consultant18 = new Consultant(18, "Perceval", "Le Gallois", new DateTime(1985, 4, 1), new DateTime(2009, 1, 1));
            var consultant19 = new Consultant(19, "Lancelot", "Du Lac", new DateTime(1982, 1, 14), new DateTime(2007, 1, 1));
            var consultant20 = new Consultant(20, "Arthur", "Roi", new DateTime(1984, 6, 12), new DateTime(2007, 1, 1));
            #endregion
            context.Consultants.Add(consultant1);
            context.Consultants.Add(consultant2);
            context.Consultants.Add(consultant3);
            context.Consultants.Add(consultant4);
            context.Consultants.Add(consultant5);
            context.Consultants.Add(consultant6);
            context.Consultants.Add(consultant7);
            context.Consultants.Add(consultant8);
            context.Consultants.Add(consultant9);
            context.Consultants.Add(consultant10);
            context.Consultants.Add(consultant11);
            context.Consultants.Add(consultant12);
            context.Consultants.Add(consultant13);
            context.Consultants.Add(consultant14);
            context.Consultants.Add(consultant15);
            context.Consultants.Add(consultant16);
            context.Consultants.Add(consultant17);
            context.Consultants.Add(consultant18);
            context.Consultants.Add(consultant19);
            context.Consultants.Add(consultant20);
            context.SaveChanges();
            #region teams
            var team1 = new Team { Id = 1, Name = "Team1" };
            team1.SetManager(consultant1);
            team1.AddAllAsMember(new List<Consultant> { consultant2 });
            var team2 = new Team { Id = 2, Name = "Team2"};
            team2.SetManager(consultant6);
            team2.AddAllAsMember(new List<Consultant> { consultant7, consultant8, consultant9, consultant10, consultant11 });
            var team3 = new Team { Id = 3, Name = "Team3"};
            team3.SetManager(consultant12);
            team3.AddAllAsMember(new List<Consultant> { consultant13, consultant14, consultant15, consultant16 });
            var team4 = new Team { Id = 4, Name = "Team4" };
            team4.SetManager(consultant20);
            team1.AddAllAsMember(new List<Consultant> { consultant17, consultant18, consultant19 });
            #endregion
            context.SaveChanges();
            var missionCount = 0;
            consultant1.Missions.Add(new Mission { Id = ++missionCount, Customer = customer1, Competencies = { reporting }, StartDate = new DateTime(1988, 1, 1), EndDate = new DateTime(1995, 12, 31) });
            consultant1.Missions.Add(new Mission { Id = ++missionCount, Customer = customer2, Competencies = { sql }, StartDate = new DateTime(1995, 1, 1), EndDate = new DateTime(2001, 12, 31) });
            consultant1.Missions.Add(new Mission { Id = ++missionCount, Customer = customer1, Competencies = { sql }, StartDate = new DateTime(2002, 2, 1), EndDate = new DateTime(2012, 12, 31) });

            consultant2.Missions.Add(new Mission { Id = ++missionCount, Customer = customer2, Competencies = { sql }, StartDate = new DateTime(1995, 1, 1), EndDate = new DateTime(2005, 12, 31) });
            consultant2.Missions.Add(new Mission { Id = ++missionCount, Customer = customer1, Competencies = { sql,reporting }, StartDate = new DateTime(2005, 1, 1), EndDate = new DateTime(2010, 12, 31) });

            consultant3.Missions.Add(new Mission { Id = ++missionCount, Customer = customer3, Competencies = { java, spring }, StartDate = new DateTime(2000, 1, 1), EndDate = new DateTime(2002, 6, 30) });
            consultant3.Missions.Add(new Mission { Id = ++missionCount, Customer = customer1, Competencies = { sql, reporting }, StartDate = new DateTime(2002, 8, 1), EndDate = new DateTime(2004, 12, 31) });

            consultant4.Missions.Add(new Mission { Id = ++missionCount, Customer = customer4, Competencies = { cobol }, StartDate = new DateTime(1992, 1, 1), EndDate = new DateTime(1996, 6, 30) });
            consultant4.Missions.Add(new Mission { Id = ++missionCount, Customer = customer4, Competencies = { cobol,java}, StartDate = new DateTime(1996,7, 1), EndDate = new DateTime(1999, 3, 31) });

            consultant5.Missions.Add(new Mission { Id = ++missionCount, Customer = customer4, Competencies = { cobol }, StartDate = new DateTime(1992, 1, 1), EndDate = new DateTime(1996, 6, 30) });
            consultant5.Missions.Add(new Mission { Id = ++missionCount, Customer = customer4, Competencies = { cobol,java }, StartDate = new DateTime(1996, 7, 1), EndDate = new DateTime(1999, 3, 31) });

            consultant6.Missions.Add(new Mission { Id = ++missionCount, Customer = customer4, Competencies = { cobol }, StartDate = new DateTime(1992, 1, 1), EndDate = new DateTime(1996, 6, 30) });
            AddMission(++missionCount, consultant6, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant7, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant8, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant9, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant10, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant11, customer3, new List<Competency> { dotnet },null, new DateTime(2015,12,31));
            AddMission(++missionCount, consultant6, customer4, new List<Competency> { dotnet,linq }, new DateTime(2016, 1, 1));
            AddMission(++missionCount, consultant7, customer4, new List<Competency> { dotnet,linq }, new DateTime(2016, 4, 1));
            AddMission(++missionCount, consultant8, customer4, new List<Competency> { dotnet,linq }, new DateTime(2016, 1, 1));
            AddMission(++missionCount, consultant9, customer6, new List<Competency> { dotnet,linq }, new DateTime(2016, 1, 1));
            AddMission(++missionCount, consultant10, customer6, new List<Competency> { dotnet,linq }, new DateTime(2016, 2, 1));
            AddMission(++missionCount, consultant11, customer6, new List<Competency> { dotnet,linq }, new DateTime(2016, 2, 1));
            AddMission(++missionCount, consultant12, customer3, new List<Competency> { dotnet, linq, js, ng });
            AddMission(++missionCount, consultant12, customer5, new List<Competency> { reporting, bo, sql }, null, new DateTime(2005, 12, 31));
            AddMission(++missionCount, consultant13, customer5, new List<Competency> { reporting, bo, sql }, null, new DateTime(2005, 12, 31));
            AddMission(++missionCount, consultant12, customer6, new List<Competency> { reporting, bo, sql }, new DateTime(2006,1,1));
            AddMission(++missionCount, consultant13, customer1, new List<Competency> { reporting, bo, sql }, new DateTime(2006, 1, 1));
            AddMission(++missionCount, consultant15, customer3, new List<Competency> { java },null, new DateTime(2015, 1, 1));
            AddMission(++missionCount, consultant16, customer3, new List<Competency> { java }, null, new DateTime(2015, 1, 1));
            AddMission(++missionCount, consultant15, customer2, new List<Competency> { java }, new DateTime(2015, 1, 1));
            AddMission(++missionCount, consultant16, customer1, new List<Competency> { java,spring }, new DateTime(2015, 4, 1));
            AddMission(++missionCount, consultant17, customer2, new List<Competency> { js }, null, new DateTime(2012, 6, 30));
            AddMission(++missionCount, consultant18, customer2, new List<Competency> { js }, null, new DateTime(2012, 6, 30));
            AddMission(++missionCount, consultant19, customer2, new List<Competency> { js }, null, new DateTime(2012, 6, 30));
            AddMission(++missionCount, consultant20, customer2, new List<Competency> { js }, null, new DateTime(2012, 6, 30));
            AddMission(++missionCount, consultant17, customer3, new List<Competency> { js, ng }, new DateTime(2012, 7, 1), new DateTime(2015, 12, 31));
            AddMission(++missionCount, consultant18, customer3, new List<Competency> { js }, new DateTime(2012, 8, 1), new DateTime(2015, 12, 31));
            AddMission(++missionCount, consultant18, customer2, new List<Competency> { js }, new DateTime(2016, 2, 1), new DateTime(2017, 12, 31));
            AddMission(++missionCount, consultant18, customer1, new List<Competency> { js }, new DateTime(2017, 1, 1));
            AddMission(++missionCount, consultant19, customer4, new List<Competency> { js, ng, java }, new DateTime(2012, 7, 1));
            AddMission(++missionCount, consultant20, customer4, new List<Competency> { js, ng, java }, new DateTime(2012, 7, 1), new DateTime(2015, 6, 30));
            AddMission(++missionCount, consultant20, customer5, new List<Competency> { js, ng, dotnet, linq }, new DateTime(2015, 7, 1), new DateTime(2016, 11, 30));
            AddMission(++missionCount, consultant20, customer6, new List<Competency> { js, ng, dotnet, linq }, new DateTime(2017, 1, 1));

            context.SaveChanges();
        }

        private void AddMission(long id, Consultant c,Customer customer, List<Competency> competencies,DateTime? start=null, DateTime? end=null)
        {
            c.Missions.Add(new Mission { Id = id, Customer = customer, Competencies = competencies, StartDate = start ?? c.HireDate, EndDate = end });
        }
    }
}
