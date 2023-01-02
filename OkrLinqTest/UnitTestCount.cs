using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestCount
    {
        [Test]
        public void TestCount()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result1 = Enumerable.Count(source);
            var result2 = MoreEnumerable.Count(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestCountArgumentNullException()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Count(source));
        }
    }
}