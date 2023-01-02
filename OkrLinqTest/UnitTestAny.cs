using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestAny
    {
        [Test]
        public void Testany()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result1 = Enumerable.Any(source, x => x >= 1);
            var result2 = MoreEnumerable.Any(source, x => x >= 1);
            Assert.AreEqual(result1, result2);
        }


        [Test]
        public void Testany2()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result1 = Enumerable.Any(source);
            var result2 = MoreEnumerable.Any(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestanyArgumentNullException1()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Any(source));
        }

        [Test]
        public void TestanyArgumentNullException2()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            System.Func<int, bool> predicate = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Any(source, predicate));
        }
    }
}