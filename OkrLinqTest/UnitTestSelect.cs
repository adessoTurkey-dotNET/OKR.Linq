using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestSelect
    {
        [Test]
        public void TestSelect()
        {
            int[] source = { 1,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.Select(source, x=> x > 3);
            var result2 = MoreEnumerable.Select(source, x => x > 3);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSelect2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            int[] result1 = { 3, 4, 5, 6 };
            var result2 = MoreEnumerable.Select(source, (x, index) => index >= 3 && x >= 3);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSelectArgumentNullException()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Select(source, x => x > 3));
        }

        [Test]
        public void TestSelectArgumentNullException2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            System.Func<int, int, bool> predicate = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Select(source, predicate));
        }

    }
}