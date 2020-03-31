using NUnit.Framework;

namespace p9SUBS.tests
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
            var result = Class1.findAllOccurencesOfSubstring("GATATATGCATATACTT", "ATAT");
            Assert.Contains(2, result);
            Assert.Contains(4, result);
            Assert.Contains(10, result);
        }
        [Test]
        public void SampleTestFromDisk()
        {
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem9SUBS\p9SUBS.tests\rosalind_subs.txt");
            string firstLine = text.Substring(0, text.IndexOf("\r\n"));
            string secondLine = text.Substring(text.IndexOf("\r\n") + 2);//Just manually strip the ending CRLF if its there

            var result = Class1.findAllOccurencesOfSubstring(firstLine, secondLine);

            string resultString = "";
            foreach (var res in result) 
            {
                resultString = resultString + " " + res;
            }
            System.Console.WriteLine(resultString);
            Assert.Contains(2, result);
            Assert.Contains(4, result);
            Assert.Contains(10, result);
        }
        [Test]
        public void ActualFromDisk()
        {
            string text = System.IO.File.ReadAllText(@"C:\git\rosalind\problem9SUBS\p9SUBS.tests\rosalind_subs_real.txt");
            string firstLine = text.Substring(0, text.IndexOf("\r\n"));
            string secondLine = text.Substring(text.IndexOf("\r\n") + 2);//Just manually strip the ending CRLF if its there

            var result = Class1.findAllOccurencesOfSubstring(firstLine, secondLine);

            string resultString = "";
            foreach (var res in result)
            {
                resultString = resultString + " " + res;
            }
            System.Console.WriteLine(resultString);
            Assert.Pass();
        }
    }
}