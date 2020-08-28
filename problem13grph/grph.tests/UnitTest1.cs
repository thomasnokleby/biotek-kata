using NUnit.Framework;

namespace grph.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SampleTestData()
        {
            var runClass = new grph.Class1();
            var result = runClass.findOverlapGraph(@"c:\git\rosalind\problem13grph\grph.tests\Sample.fst");
            Assert.Pass();
        }

        [Test]
        public void ActualTestData()
        {
            var runClass = new grph.Class1();
            var result = runClass.findOverlapGraph(@"c:\git\rosalind\problem13grph\grph.tests\Actual.fst");
            Assert.Pass();
        }



    }
}