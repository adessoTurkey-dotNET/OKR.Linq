using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestLast
    {
        [Test]
        public void TestLast()
        {
            int[] source = { 1,2,3,1,2,3,4,5,6};
            var result1 = Enumerable.Last(source, x=> x == 1);
            var result2 = MoreEnumerable.Last(source, x => x == 1 );
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestLast2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            var result1 = Enumerable.Last(source);
            var result2 = MoreEnumerable.Last(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestLastArgumentNullException()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.Last(source, x => x >6));
        }

        [Test]
        public void TestLastArgumentNullException2()
        {
            int[] source = { };
            Assert.Throws<System.InvalidOperationException>(() => MoreEnumerable.Last(source));
        }
    }
}