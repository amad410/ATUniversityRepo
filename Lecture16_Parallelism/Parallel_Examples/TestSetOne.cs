using NUnit.Framework;

namespace Lecture16_Parallelism
{
    [NonParallelizable]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test1()
        {
            new ThreadTest();
            Assert.Pass();
        }
    }
}