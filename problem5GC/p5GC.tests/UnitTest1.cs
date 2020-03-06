using System;
using NUnit.Framework;

namespace p5GC.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RunSampleData()
        {
            var parsedDNA = p5GC.Class1.loadFASTA(@"c:\git\rosalind\problem5GC\p5GC.tests\sampledata.fasta");
            var highestGCLDNA = p5GC.Class1.getHighestGCContent(parsedDNA);
            var highestGCContent = p5GC.Class1.findGCContent(highestGCLDNA);
            Assert.IsTrue(DoublesAreEqual(60.919540d, highestGCContent,0.001f));
        }

        [Test]
        public void RunActualData() 
        {
            var parsedDNA = p5GC.Class1.loadFASTA(@"c:\git\rosalind\problem5GC\p5GC.tests\rosalind_gc.txt");
            var highestGCLDNA = p5GC.Class1.getHighestGCContent(parsedDNA);
            var highestGCContent = p5GC.Class1.findGCContent(highestGCLDNA);
            Assert.Pass();
        }

        private bool DoublesAreEqual(double expected, double highestGCContent, float errorAllowed)
        {
            return (highestGCContent + errorAllowed > expected && highestGCContent - errorAllowed < expected);
        }
    }
}