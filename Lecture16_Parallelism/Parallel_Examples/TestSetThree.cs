using NUnit.Framework;

namespace Lecture16_Parallelism
{
    [Parallelizable(ParallelScope.Children)]
    public class TestsThree
    {        
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test1()
        {
            new ThreadTest();
            Assert.Pass();
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test2()
        {
            new ThreadTest();
            Assert.Pass();
        }

        [Test]
        [Parallelizable(ParallelScope.None)]
        public void Test3()
        {
            new ThreadTest();
            Assert.Pass();
        }

        [SetUp]
        public void Setup()
        {
        }

    }
}