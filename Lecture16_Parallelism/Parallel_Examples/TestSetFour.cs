using NUnit.Framework;

namespace Lecture16_Parallelism
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestSetFour
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