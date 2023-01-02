using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestRange
    {
        [Test]
        public void TestRange()
        {
            var result1 = Enumerable.Range(1, 100);
            var result2 = MoreEnumerable.Range(1, 100);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSelectArgumentNullException2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            Assert.Throws<System.ArgumentOutOfRangeException>(() => MoreEnumerable.Range(1, -1));
        }
    }
}