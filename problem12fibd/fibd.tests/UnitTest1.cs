using NUnit.Framework;

namespace fibd.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Synthetic()
        {
            var MortalRabbits = new MortalRabbits();

            var population = MortalRabbits.simulateRabbits(6,3);

            Assert.AreEqual(population,4);
        }

        [Test]
        public void Syntetic_Optimized()
        {
            var MortalRabbits = new MortalRabbits();

            var population = MortalRabbits.simulateRabbitsOptimized(6, 3);

            Assert.AreEqual(4, population);
        }

        [Test]
        public void Live_Data_Optimized_2ndTryBigNum()
        {
            var MortalRabbits = new MortalRabbits();

            var population = MortalRabbits.simulateRabbitsOptimizedBigNum(84, 19);

            Assert.AreEqual(population, 159988278874468261);
        }
    }
}