using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestOrderBy
    {
        private class MyMap
        {
            public int MyProperty1 { get; set; }
            public string MyProperty2 { get; set; }
        }
        [Test]
        public void TestOrderBy()
        {
            var map = new System.Collections.Generic.List<MyMap>() { new MyMap { MyProperty1 = 2, MyProperty2 = "ilk" }, new MyMap { MyProperty1 = 1, MyProperty2 = "iki" } };
            var result1 = Enumerable.OrderByDescending(map, x=> x.MyProperty1);
            var result2 = MoreEnumerable.OrderBy(map, x => x.MyProperty1, OrderByDirection.Descending);
            Assert.AreEqual(result1, result2);
        }
    }
}