using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinqTest
{
    public class UnitTestAll
    {
        [Test]
        public void TestAll()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result1 = Enumerable.All(source, x => x >= 1);
            var result2 = MoreEnumerable.All(source, x => x >= 1);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestAllArgumentNullException1()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.All(source, x => x >= 1));
        }

        [Test]
        public void TestAllArgumentNullException2()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            System.Func<int, bool> predicate = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.All(source, predicate));
        }
    }
}