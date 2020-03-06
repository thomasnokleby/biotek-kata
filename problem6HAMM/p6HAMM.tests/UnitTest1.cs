using NUnit.Framework;

namespace p6HAMM.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSampleDataSet()
        {
            var DNAA = "GAGCCTACTAACGGGAT";
            var DNAB = "CATCGTAATGACGGCCT";
            Assert.AreEqual(7, p6HAMM.Class1.HammingDistance(DNAA, DNAB));
        }

        [Test]
        public void TestRealDataSet()
        {
            string text = System.IO.File.ReadAllText(@"c:\git\rosalind\problem6HAMM\p6HAMM.tests\rosalind_hamm.txt");
            var firstBreak = text.IndexOf("\r\n");
            string dnaA = text.Substring(0,firstBreak);
            string dnaB = text.Substring(firstBreak + 2, (text.Length - (firstBreak+4)));
            var hammdist = p6HAMM.Class1.HammingDistance(dnaA,dnaB);
            System.Console.WriteLine(hammdist);
        }
    }
}