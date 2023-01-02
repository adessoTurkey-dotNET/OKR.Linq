using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestFirstOrDefault
    {
        [Test]
        public void TestFirstOrDefault()
        {
            int[] source = { 1,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.FirstOrDefault(source, x=>x>6);
            var result2 = MoreEnumerable.FirstOrDefault(source, x => x > 6);
            Assert.AreEqual(result1, result2);
        }
    }
}