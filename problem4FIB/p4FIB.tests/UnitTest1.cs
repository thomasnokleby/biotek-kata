using NUnit.Framework;

namespace p4FIB.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SampleDataset()
        {
            var result = p4FIB.computeFibWithKMultiplier(5, 3);
            Assert.AreEqual(19L,result);
        }

        [Test]
        public void RealDataset()
        {
            var result = p4FIB.computeFibWithKMultiplier(31, 4);
            Assert.AreEqual(1117836738901L, result);
        }
    }
}