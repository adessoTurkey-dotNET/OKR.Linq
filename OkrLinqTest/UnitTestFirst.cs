using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestFirst
    {
        [Test]
        public void TestFirst()
        {
            int[] source = { 1,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.First(source, x=>x>5);
            var result2 = MoreEnumerable.First(source, x => x > 5);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestFirst2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            var result1 = Enumerable.First(source);
            var result2 = MoreEnumerable.First(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestFirstArgumentNullException()
        {
            int[] source = { };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.First(source));
        }

        [Test]
        public void TestFirstArgumentNullException2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };

            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.First(source, x => x > 6));
        }
    }
}