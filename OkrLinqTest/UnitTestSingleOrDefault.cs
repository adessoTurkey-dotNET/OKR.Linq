using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestSingleOrDefault
    {
        [Test]
        public void TestSingleOrDefault()
        {
            int[] source = { 2,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.SingleOrDefault(source, x=> x < 1);
            var result2 = MoreEnumerable.SingleOrDefault(source, x => x < 1);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSingleOrDefaultInvalidOperationException()
        {
            int[] source = { 2, 2 };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.SingleOrDefault(source));
        }

        [Test]
        public void TestSingleOrDefaultInvalidOperationException2()
        {
            int[] source = { 2, 2 };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.SingleOrDefault(source, x=>x == 2));
        }
    }
}