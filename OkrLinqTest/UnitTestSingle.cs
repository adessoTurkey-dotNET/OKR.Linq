using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestSingle
    {
        [Test]
        public void TestSingle()
        {
            int[] source = { 2,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.Single(source, x=> x < 2);
            var result2 = MoreEnumerable.Single(source, x => x < 2);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSingleOrDefaultInvalidOperationException()
        {
            int[] source = { 2, 2 };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.Single(source));
        }

        [Test]
        public void TestSingleOrDefaultInvalidOperationException2()
        {
            int[] source = { 2, 2 };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.Single(source, x => x > 6));
        }
    }
}