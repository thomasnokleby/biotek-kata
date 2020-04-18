using NUnit.Framework;

namespace p10CONS.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SmallDatasetTest()
        {
            //Load fasta            
            var consensus = Class1.getConsensusFromFile(@"C:\git\rosalind\problem10CONS\p10CONS.tests\testdata.txt");            
            System.Diagnostics.Debug.WriteLine(consensus.ConsensusString);            
            System.Diagnostics.Debug.WriteLine(consensus.MatrixToString());
            Assert.Pass();
        }

        [Test]
        public void RealDatasetTest()
        {
            //Load fasta            
            var consensus = Class1.getConsensusFromFile(@"C:\git\rosalind\problem10CONS\p10CONS.tests\cons.txt");
            System.Diagnostics.Debug.WriteLine(consensus.ConsensusString);
            System.Diagnostics.Debug.WriteLine(consensus.MatrixToString());
            Assert.Pass();
        }
    }
}