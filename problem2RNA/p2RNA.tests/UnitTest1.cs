using NUnit.Framework;
using System;

namespace p2RNA.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var rna=p2RNA.Program.TranscribeDNAtoRNA("actg");
            Assert.AreEqual("acug",rna);
            Assert.Pass();
        }

        [Test]
        public void TestInitalDataset()
        {
            var rna=p2RNA.Program.TranscribeDNAtoRNA("GATGGAACTTGACTACGTAAATT");
            Assert.AreEqual("GAUGGAACUUGACUACGUAAAUU",rna);
        }
        [Test]
        public void TestActualDataset()
        {
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem2RNA\p2RNA.tests\rosalind_rna.txt"); 
            var rna=p2RNA.Program.TranscribeDNAtoRNA(text);
            System.IO.File.WriteAllText(@"..\..\..\..\RNAOutput.txt", rna);
            Assert.Pass();
        }

        
    }
}