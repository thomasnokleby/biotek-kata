using NUnit.Framework;
using System;

namespace iprb.tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Syntetic_Data()
        {
            CalculateProbability c = new CalculateProbability();
            var prob = c.computeProbability(2,2,2);
            Assert.IsTrue(DoublesEqualEnough(prob, 0.78333));
        }

        [Test]
        public void Test_Actual() 
        {
            CalculateProbability c = new CalculateProbability();
            var prob = c.computeProbability(24, 28, 19);
            Assert.IsTrue(DoublesEqualEnough(prob, 0.78611670020120727));
        }

        private static bool DoublesEqualEnough(double a, double b) 
        {
            double difference = Math.Abs(a * .00001);
            return Math.Abs(a - b) < difference;
        }
    }
}