using ContosoConsultancy.Core.Model;
using ContosoConsultancy.DataAccess;
using ContosoConsultancy.Rest.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http.Results;
using Xunit;

namespace ContosoConsultancy.Rest.Test.Controllers
{
    public class DashboardControllerTest
    {

        private static DashboardController GetDashboardController(IEnumerable<Consultant> consultants)
        {
            return GetDashboardController(consultants, dc => dc.Consultants);
        }

        private static DashboardController GetDashboardController(IEnumerable<Mission> missions)
        {
            return GetDashboardController(missions,dc => dc.Missions);
        }

        private static DashboardController GetDashboardController<T>(
            IEnumerable<T> data, 
            Expression<Func<ContosoConsultancyDataContext,DbSet<T>>> dbsetselector) 
            where T:class
        {
            var dataContextMock = new Mock<ContosoConsultancyDataContext>();
            var consultantDBSetMock = TestHelper.GetMockedDbSet(data);
            dataContextMock.Setup(dbsetselector).Returns(consultantDBSetMock.Object);
            return new DashboardController(dataContextMock.Object);
        }

        private static List<Mission> GetSomeMissions()
        {
            var now = DateTime.Now;
            var consultant1 = new Consultant { Id = 0, HireDate = DateTime.Now };
            var customer1 = new Customer { Id = 0, Name = "", Address = new Address { Country = "BE" } };
            var customer2 = new Customer { Id = 2, Name = "", Address = new Address { Country = "BE" } };
            var customer3 = new Customer { Id = 3, Name = "", Address = new Address { Country = "BE" } };
            var customer4 = new Customer { Id = 4, Name = "", Address = new Address { Country = "BE" } };

            var missions = new List<Mission> {
                    new Mission{Id=1,Consultant = consultant1,Customer = customer1,StartDate=now.AddYears(-3)},
                    new Mission{Id=2,Consultant = consultant1,Customer = customer2,StartDate=now.AddYears(-1)},
                    new Mission{Id=3,Consultant = consultant1,Customer = customer3,StartDate=now.AddYears(0)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer4,StartDate=now.AddYears(-4)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer1,StartDate=now.AddYears(-5)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer2,StartDate=now.AddYears(-6)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer2,StartDate=now.AddYears(-7)},
                };
            return missions;
        }

        public class GetIdleEmployeeCount
        {
            [Fact]
            public void Counts_consultant_without_missions()
            {
                //Arrange
                var now = DateTime.Now;
                var activeConsultant = new Consultant
                {
                    Id = 1,
                    Missions = new List<Mission> {
                        new Mission{Id=2,StartDate=now.AddDays(-5),EndDate=null},
                        new Mission{Id=1,StartDate=now.AddDays(-10),EndDate=now.AddDays(-5)}
                    }
                };
                var idleConsultant = new Consultant { Id = 2 };
                var controller = GetDashboardController(new List<Consultant> { activeConsultant, idleConsultant });
                //Act
                var count = controller.GetIdleEmployeeCount();
                //Assert
                Assert.Equal(1, count);
            }


            [Fact]
            public void Counts_consultant_with_expired_mission_only()
            {
                //Arrange
                var now = DateTime.Now;
                var activeConsultant = new Consultant
                {
                    Id = 1,
                    Missions = new List<Mission> {
                        new Mission{Id=2,StartDate=now.AddDays(-5),EndDate=null},
                        new Mission{Id=1,StartDate=now.AddDays(-10),EndDate=now.AddDays(-5)}
                    }
                };
                var idleConsultant = new Consultant { Id = 2,
                    Missions = new List<Mission> {
                        new Mission{Id=2,StartDate=now.AddDays(-20),EndDate=now.AddDays(-10)},
                        new Mission{Id=1,StartDate=now.AddDays(-10),EndDate=now.AddDays(-5)}
                    }
                };
                var controller = GetDashboardController(new List<Consultant> { activeConsultant, idleConsultant });
                //Act
                var count = controller.GetIdleEmployeeCount();
                //Assert
                Assert.Equal(1, count);
            }

            [Fact]
            public void Do_Not_Count_consultant_with_missions_end_date_in_future()
            {
                //Arrange
                var now = DateTime.Now;
                var activeConsultant = new Consultant
                {
                    Id = 1,
                    Missions = new List<Mission> {
                        new Mission{Id=2,StartDate=now.AddDays(-5),EndDate=null},
                        new Mission{Id=1,StartDate=now.AddDays(-10),EndDate=now.AddDays(-5)}
                    }
                };
                var activeConsultant2 = new Consultant
                {
                    Id = 2,
                    Missions = new List<Mission> {
                        new Mission{Id=2,StartDate=now.AddDays(-5),EndDate=now.AddDays(5)},
                        new Mission{Id=1,StartDate=now.AddDays(-10),EndDate=now.AddDays(-5)}
                    }
                };
                var controller = GetDashboardController(new List<Consultant> { activeConsultant, activeConsultant2 });
                //Act
                var count = controller.GetIdleEmployeeCount();
                //Assert
                Assert.Equal(0, count);
            }
        }

        public class GetHiredEmployeeByYear
        {
            [Fact]
            public void Can_Count_Hired_By_Year()
            {
                //Arrange
                int numberOfYears = 3;
                var now = DateTime.Now;
                var years = Enumerable.Range(0, numberOfYears).Reverse().Select(i => now.AddYears(-i)).ToList();

                var consultantYears0 = new List<Consultant> {
                    new Consultant{Id=0,HireDate = years[0] },
                    new Consultant{Id=2,HireDate = years[0] },
                    new Consultant{Id=3,HireDate = years[0] }
                };
                var consultantYears1 = new List<Consultant> {
                    new Consultant{Id=4,HireDate = years[1] }
                };
                var consultantYears2 = new List<Consultant> {
                    new Consultant{Id=5,HireDate = years[2] },
                    new Consultant{Id=6,HireDate = years[2] }
                };
                var consultantByYear = new List<Consultant>[] { consultantYears0, consultantYears1, consultantYears2 };
                var consultants = consultantYears0.Union(consultantYears1).Union(consultantYears2);
                var controller = GetDashboardController(consultants);
                
                //Act
                var hiredEmployeeByYear = controller
                    .GetHiredEmployeeByYear()
                    .ToDictionary(e => e.Key,e => e.Value);
                
                //Assert
                for (int index = 0; index < numberOfYears; index++)
                {
                    Assert.Contains(hiredEmployeeByYear, i => i.Key == years[index].Year);
                    Assert.Equal(consultantByYear[index].Count, hiredEmployeeByYear[years[index].Year]);
                }
            }

            [Fact]
            public void When_there_is_no_hiring_during_a_year_an_item_with_0_is_present_for_that_year()
            {
                //Arrange
                int numberOfYears = 3;
                var now = DateTime.Now;
                var years = Enumerable.Range(0, numberOfYears).Reverse().Select(i => now.AddYears(-i)).ToList();

                var consultantYears0 = new List<Consultant> {
                    new Consultant{Id=0,HireDate = years[0] },
                    new Consultant{Id=2,HireDate = years[0] },
                    new Consultant{Id=3,HireDate = years[0] }
                };
                var consultantYears1 = new List<Consultant> {};
                var consultantYears2 = new List<Consultant> {
                    new Consultant{Id=5,HireDate = years[2] },
                    new Consultant{Id=6,HireDate = years[2] }
                };
                var consultantByYear = new List<Consultant>[] { consultantYears0, consultantYears1, consultantYears2 };
                var consultants = consultantYears0.Union(consultantYears1).Union(consultantYears2);
                var controller = GetDashboardController(consultants);

                //Act
                var hiredEmployeeByYear = controller.GetHiredEmployeeByYear()
                    .ToDictionary(e => e.Key, e => e.Value); ;

                //Assert
                Assert.Contains(hiredEmployeeByYear, i => i.Key == years[1].Year);
                Assert.Equal(consultantByYear[1].Count, 0);
            }
        }

        public class GetNewestMission
        {


            [Fact]
            public void Limit_result_to_numberOfMissions()
            {
                //Arrange
                var numberOfMissions = 3;
                var missions = GetSomeMissions();
                var controller = GetDashboardController(missions);
                //Act
                var result = controller.GetNewestMission(numberOfMissions);
                //Assert
                Assert.Equal(numberOfMissions, result.Count());
            }

            [Fact]
            public void Result_are_ordered_by_date()
            {
                //Arrange
                var numberOfMissions = 3;
                var missions = GetSomeMissions();
                var controller = GetDashboardController(missions);
                //Act
                var result = controller.GetNewestMission(numberOfMissions).ToList();
                //Assert
                var resultWithIndex = result.Select((m, idx) => new { Mission = m, Index = idx });
                var resultWithNext = resultWithIndex
                    .Join(resultWithIndex, i => i.Index, o => o.Index - 1, 
                    (i, o) => new {Current=i.Mission,Next=o.Mission });
                Assert.All(resultWithNext, i => Assert.True(i.Current.StartDate > i.Next.StartDate));
            }
        }

        public class GetTopClient
        {
            [Fact]
            public void Consider_only_active_missions()
            {
                var numberOfCustomer = 1;
                var now = DateTime.Now;
                var consultant1 = new Consultant { Id = 0, HireDate = DateTime.Now };
                var customer1 = new Customer { Id = 0, Name = "", Address = new Address { Country = "BE" } };
                var customer2 = new Customer { Id = 2, Name = "", Address = new Address { Country = "BE" } };
                var customer3 = new Customer { Id = 3, Name = "", Address = new Address { Country = "BE" } };

                var missions = new List<Mission> {
                    new Mission{Id=1,Consultant = consultant1,Customer = customer1,StartDate=now.AddYears(-3),EndDate=now.AddYears(-2)},
                    new Mission{Id=2,Consultant = consultant1,Customer = customer1,StartDate=now.AddYears(-2),EndDate=now.AddYears(-1)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer2,StartDate=now.AddYears(-1),EndDate=now.AddMonths(-1)},
                    new Mission{Id=4,Consultant = consultant1,Customer = customer2,StartDate=now.AddYears(-1)},
                };

                var controller = GetDashboardController(missions);
                var result = controller.GetTopClient(numberOfCustomer).ToList();
                Assert.Equal(1, result.Count);
                Assert.Equal(customer2.Id, result.Single().Id);
                Assert.Equal(1, result.Single().NumberOfMissions);
            }
            [Fact]
            public void Limit_result_to_numberOfCustomer()
            {
                //Arrange
                var numberOfCustomer = 3;
                var missions = GetSomeMissions();
                var controller = GetDashboardController(missions);
                //Act
                var result = controller.GetTopClient(numberOfCustomer).ToList();
                //Assert
                Assert.Equal(3, result.Count);
            }

            [Fact]
            public void Result_are_ordered_by_mission_number()
            {
                //Arrange
                var numberOfCustomer = 3;
                var missions = GetSomeMissions();
                var controller = GetDashboardController(missions);
                //Act
                var result = controller.GetTopClient(numberOfCustomer).ToList();
                //Assert
                var resultWithIndex = result.Select((m, idx) => new { Customer = m, Index = idx });
                var resultWithNext = resultWithIndex
                    .Join(resultWithIndex, i => i.Index, o => o.Index - 1,
                    (i, o) => new { Current = i.Customer, Next = o.Customer });
                Assert.All(resultWithNext, i => Assert.True(i.Current.NumberOfMissions > i.Next.NumberOfMissions));
            }

        }
    }
}
