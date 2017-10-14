using ContosoConsultancy.Core.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoConsultancy.Rest.Test.Controllers
{
    public class TestHelper
    {
        public static Mock<DbSet<T>> GetMockedDbSet<T>(IQueryable<T> mockData) where T:class
        {
            var consultantDBSetMock = new Mock<DbSet<T>>();
            consultantDBSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(mockData.Provider);
            consultantDBSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(mockData.Expression);
            consultantDBSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(mockData.ElementType);
            consultantDBSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());
            return consultantDBSetMock;
        }

        public static Mock<DbSet<T>> GetMockedDbSet<T>(IEnumerable<T> mockData) where T : class
        {
            return GetMockedDbSet(mockData.AsQueryable());
        }
    }
}
