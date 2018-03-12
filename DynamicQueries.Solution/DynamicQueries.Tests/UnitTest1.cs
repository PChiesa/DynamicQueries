using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicQueries.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void WhereQuery()
        {
            string[] companies = { "Consolidated Messenger", "Alpine Ski House", "Southridge Video", "City Power & Light",
                   "Coho Winery", "Wide World Importers", "Graphic Design Institute", "Adventure Works",
                   "Humongous Insurance", "Woodgrove Bank", "Margie's Travel", "Northwind Traders",
                   "Blue Yonder Airlines", "Trey Research", "The Phone Company",
                   "Wingtip Toys", "Lucerne Publishing", "Fourth Coffee" };

            IQueryable<string> queryableData = companies.AsQueryable<string>();

            var filter = new Dictionary<string, object>();
            filter.Add("", "Fourth Coffee");

            var whereCriteria = new WhereCriteria<string>(new CriteriaParameters() { SingleProperty = filter });
            var builder = new CriteriaBuilder<string>(whereCriteria);

            var result = builder.Materialize(builder.Build(queryableData));

            Assert.AreEqual("Fourth Coffee", "Fourth Coffee");
        }
    }
}
