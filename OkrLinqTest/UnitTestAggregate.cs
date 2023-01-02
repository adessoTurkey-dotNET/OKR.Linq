using OkrLinq;
using NUnit.Framework;
using System.Linq;

namespace OkrLinq
{
    public class UnitTestAggregate
    {
        [Test]
        public void TestAggregate()
        {
            int[] source = { 1, 4, 5 };
            int seed = 5;
            System.Func<int, int, int> func = (current, value) => current * 2 + value;
            System.Func<int, string> resultSelector = result => result.ToString();
            var result1 = Enumerable.Aggregate(source, seed, func, resultSelector);
            var result2 = MoreEnumerable.Aggregate(source, seed, func, resultSelector);
            Assert.AreEqual(result1, result2);
        }

        [Test]
        public void TestAggregateArgumentNullException1()
        {
            int[] source = null;
            int seed = 5;
            System.Func<int, int, int> func = (current, value) => current * 2 + value;
            System.Func<int, string> resultSelector = result => result.ToString();
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Aggregate(source, seed, func, resultSelector));
        }

        [Test]
        public void TestAggregateArgumentNullException2()
        {
            int[] source = { 1, 4, 5 };
            int seed = 5;
            System.Func<int, int, int> func = null;
            System.Func<int, string> resultSelector = result => result.ToString();
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Aggregate(source, seed, func, resultSelector));
        }

        [Test]
        public void TestAggregateArgumentNullException3()
        {
            int[] source = { 1, 4, 5 };
            int seed = 5;
            System.Func<int, int, int> func = (current, value) => current * 2 + value;
            System.Func<int, string> resultSelector = null;
            Assert.Throws<System.ArgumentNullException>(() => MoreEnumerable.Aggregate(source, seed, func, resultSelector));
        }

    }
}