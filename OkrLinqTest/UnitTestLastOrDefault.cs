using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestLastOrDefault
    {
        [Test]
        public void TestLastOrDefault()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            var result1 = Enumerable.LastOrDefault(source, x => x < 0);
            var result2 = MoreEnumerable.LastOrDefault(source, x => x < 0);
            Assert.AreEqual(result1, result2);
        }
    }
}