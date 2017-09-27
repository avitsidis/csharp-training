using ContosoConsultancy.Core.Model;
using ContosoConsultancy.Rest.Controllers;
using ContosoConsultancy.Rest.Models.Consultants;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http.Routing;
using Xunit;

namespace ContosoConsultancy.Rest.Test
{
    public class ConsultantsControllerTest
    {
        private IQueryable<Consultant> GetSomeConsultants() {
            var team1 = new Team() { Name = "Team1", Id = 1 };
            var consultant1 = new Consultant { Name = "Foo1", FirstName = "Bar1", BirthDate = DateTime.MinValue, DisengagedDate = DateTime.MaxValue, Id = 1, Team = team1 };
            var consultant2 = new Consultant { Name = "Foo2", FirstName = "Bar2", BirthDate = DateTime.MinValue, DisengagedDate = DateTime.MaxValue, Id = 2, Team = team1 };
            var team2 = new Team() { Name = "Team2", Id = 2 };
            var consultant3 = new Consultant { Name = "John3", FirstName = "Doo3", BirthDate = DateTime.MinValue, DisengagedDate = DateTime.MaxValue, Id = 3, Team = team2 };
            var consultant4 = new Consultant { Name = "John4", FirstName = "Doo4", BirthDate = DateTime.MinValue, DisengagedDate = DateTime.MaxValue, Id = 4, Team = team2 };

            team1.Members.Add(consultant1);
            team1.Members.Add(consultant2);
            team2.Members.Add(consultant3);
            team2.Members.Add(consultant4);

            return new List<Consultant>
            {
                consultant1,
                consultant2,
                consultant3,
                consultant4
            }.AsQueryable();
        }

        private Mock<DbSet<Consultant>> GetMockedDbSet(IQueryable<Consultant> mockData)
        {
            var consultantDBSetMock = new Mock<DbSet<Consultant>>();
            consultantDBSetMock.As<IQueryable<Consultant>>().Setup(m => m.Provider).Returns(mockData.Provider);
            consultantDBSetMock.As<IQueryable<Consultant>>().Setup(m => m.Expression).Returns(mockData.Expression);
            consultantDBSetMock.As<IQueryable<Consultant>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            consultantDBSetMock.As<IQueryable<Consultant>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            return consultantDBSetMock;
        }

        private ConsultantsController GetConsultantsController(IQueryable<Consultant> consultants)
        {
            var dataContextMock = new Mock<DataAccess.ContosoConsultancyDataContext>();
            var consultantDBSetMock = GetMockedDbSet(consultants);
            var urlHelperMock = new Mock<UrlHelper>();
            dataContextMock.Setup(m => m.Consultants).Returns(consultantDBSetMock.Object);
            urlHelperMock.Setup(u => u.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("");
            var controller = new ConsultantsController(dataContextMock.Object)
            {
                Url = urlHelperMock.Object
            };
            return controller;
        }


        [Fact]
        public void Returns_all_consultants_when_no_filter_has_been_set()
        {
            //Arrange
            var consultants = GetSomeConsultants();
            var controller = GetConsultantsController(consultants);

            //Act
            var search = new SearchConsultantModel { };
            var result = controller.GetConsultants(search);

            //Assert
            Assert.True(result.Count() == consultants.Count());
        }

        [Fact]
        public void Returns_consultants_matching_provided_name()
        {
            //Arrange
            var consultants = GetSomeConsultants();
            var controller = GetConsultantsController(consultants);

            //Act
            var search = new SearchConsultantModel { Name = "foo" };
            var result = controller.GetConsultants(search);

            //Assert
            Assert.Contains(result, c => c.Id == 1);
            Assert.Contains(result, c => c.Id == 2);
            Assert.DoesNotContain(result, c => c.Id == 3);
            Assert.DoesNotContain(result, c => c.Id == 4);
        }

        [Fact]
        public void Returns_consultants_matching_provided_firstname()
        {
            //Arrange
            var consultants = GetSomeConsultants();
            var controller = GetConsultantsController(consultants);

            //Act
            var search = new SearchConsultantModel { FirstName = "bar" };
            var result = controller.GetConsultants(search);

            //Assert
            Assert.Contains(result, c => c.Id == 1);
            Assert.Contains(result, c => c.Id == 2);
            Assert.DoesNotContain(result, c => c.Id == 3);
            Assert.DoesNotContain(result, c => c.Id == 4);
        }


        [Fact]
        public void Returns_consultants_matching_provided_teamname()
        {
            //Arrange
            var consultants = GetSomeConsultants();
            var controller = GetConsultantsController(consultants);

            //Act
            var search = new SearchConsultantModel { TeamName = "Team2" };
            var result = controller.GetConsultants(search);

            //Assert
            Assert.Contains(result, c => c.Id == 3);
            Assert.Contains(result, c => c.Id == 4);
            Assert.DoesNotContain(result, c => c.Id == 1);
            Assert.DoesNotContain(result, c => c.Id == 2);
        }
    }
}
