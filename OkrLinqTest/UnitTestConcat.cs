using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestConcat
    {
        [Test]
        public void TestConcat()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            int[] source2 = { 3, 7, 2 };
            var result1 = Enumerable.Concat(source, source2);
            var result2 = MoreEnumerable.Concat(source, source2);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestConcatArgumentNullException1()
        {
            int[] source = null;
            int[] source2 = { 3, 7, 2 };
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Concat(source, source2));
        }

        [Test]
        public void TestConcatArgumentNullException2()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            int[] source2 = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Concat(source, source2));
        }
    }
}