using NUnit.Framework;
using p1DNA;
using System;

namespace p1DNA.tests
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
            var result  = Problem1Impl.countACGT("ACGT");
            Assert.IsTrue(result.ACount == 1);
            Assert.IsTrue(result.CCount == 1);
            Assert.IsTrue(result.GCount == 1);
            Assert.IsTrue(result.TCount == 1);
        }

        [Test]
        public void Test2()
        {
            var result  = Problem1Impl.countACGT("ACGTACGT");
            Assert.IsTrue(result.ACount == 2);
            Assert.IsTrue(result.CCount == 2);
            Assert.IsTrue(result.GCount == 2);
            Assert.IsTrue(result.TCount == 2);
        }

        [Test]
        public void TestFromFile()
        {
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem1DNA\p1DNA.tests\DNA.txt");
            var result  = Problem1Impl.countACGT(text);
            Console.WriteLine(result.ACount + " " + result.CCount + " " + result.GCount + " " + result.TCount);
            TestContext.Out.WriteLine(result.ACount + " " + result.CCount + " " + result.GCount + " " + result.TCount);
            System.Diagnostics.Trace.WriteLine(result.ACount + " " + result.CCount + " " + result.GCount + " " + result.TCount);
            System.Diagnostics.Debug.WriteLine(result.ACount + " " + result.CCount + " " + result.GCount + " " + result.TCount);
            //Fail test to actually get output (run dotnet test -v n)
            Assert.Fail();
        }
         [Test]
        public void TestUsingRealTestdata()
        {
            var result  = Problem1Impl.countACGT("AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC");
            Assert.IsTrue(result.ACount == 20);
            Assert.IsTrue(result.CCount == 12);
            Assert.IsTrue(result.GCount == 17);
            Assert.IsTrue(result.TCount == 21);
        }


    }
}