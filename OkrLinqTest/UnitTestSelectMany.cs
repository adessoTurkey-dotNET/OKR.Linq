using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestSelectMany
    {
        private class MyMap
        {
            public int MyProperty1 { get; set; }
            public string MyProperty2 { get; set; }
        }
        [Test]
        public void TestSelectMany()
        {
            var map = new System.Collections.Generic.List<MyMap>() { new MyMap { MyProperty1 = 2, MyProperty2 = "ilk" }, new MyMap { MyProperty1 = 1, MyProperty2 = "iki" } };
            var result1 = Enumerable.SelectMany(map, x => x.MyProperty2);
            var result2 = MoreEnumerable.SelectMany(map, x => x.MyProperty2);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSelectManyArgumentNullException()
        {
            System.Collections.Generic.List<MyMap> map = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.SelectMany(map, x => x.MyProperty2));
        }

        [Test]
        public void TestSelectManyArgumentNullException2()
        {
            var map = new System.Collections.Generic.List<MyMap>() { new MyMap { MyProperty1 = 2, MyProperty2 = "ilk" }, new MyMap { MyProperty1 = 1, MyProperty2 = "iki" } };
            System.Func<MyMap, System.Collections.Generic.IEnumerable<MyMap>> selector = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.SelectMany(map, selector));
        }
    }
}