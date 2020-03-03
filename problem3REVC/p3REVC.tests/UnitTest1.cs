using NUnit.Framework;

namespace p3REVC.tests
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
            var result = p3REVC.ComplementDNA("AAAACCCGGT");
            Assert.AreEqual(result, "ACCGGGTTTT");
        }

        [Test]
        public void ActualData()
        {       
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem3REVC\rosalind_revc.txt");
            var cDNA = p3REVC.ComplementDNA(text);
            System.IO.File.WriteAllText(@"..\..\..\..\Output.txt", cDNA);
            Assert.Pass();
        }
    }
}