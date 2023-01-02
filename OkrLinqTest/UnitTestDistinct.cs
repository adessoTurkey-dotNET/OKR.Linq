using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestDistinct
    {
        [Test]
        public void TestDistinct()
        {
            int[] source = { 1,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.Distinct(source);
            var result2 = MoreEnumerable.Distinct(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestDistinctArgumentNullException2()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Distinct(source));
        }
    }
}