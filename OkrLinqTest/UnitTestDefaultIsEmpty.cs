using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestDefaultIsEmpty
    {
        [Test]
        public void TestDefaultIsEmpty()
        {
            int[] source = { };
            var result1 = Enumerable.DefaultIfEmpty(source);
            var result2 = MoreEnumerable.DefaultIfEmpty(source);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestDefaultIsEmptyArgumentNullException()
        {
            int[] source = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.DefaultIfEmpty(source));
        }
    }
}