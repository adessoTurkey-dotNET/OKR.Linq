using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestRepeat
    {
        [Test]
        public void TestRepeat()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            var result1 = Enumerable.Repeat(source, 2);
            var result2 = MoreEnumerable.Repeat(source, 2);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestSelectArgumentNullException2()
        {
            int[] source = { 1, 2, 3, 1, 2, 3, 4, 5, 6 };
            Assert.Throws<System.ArgumentOutOfRangeException>(() => MoreEnumerable.Repeat(source, -1));
        }
    }
}