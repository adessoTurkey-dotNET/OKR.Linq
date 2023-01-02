using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestWhere
    {
        [Test]
        public void TestWhere()
        {
            int[] source = { 2,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.Where(source, x=> x < 1);
            var result2 = MoreEnumerable.Where(source, x => x < 1);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void NullSourceThrowsNullArgumentException()
        {
            System.Collections.Generic.IEnumerable<int> source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Where(source, x => x > 5));
        }
        [Test]
        public void NullPredicateThrowsNullArgumentException()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            System.Func<int, bool> predicate = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Where(source, predicate));
        }
    }
}