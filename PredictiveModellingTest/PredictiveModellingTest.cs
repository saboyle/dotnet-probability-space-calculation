using NUnit.Framework;
using PredictiveModelling;

namespace PrectiveModellingTest
{
    [TestFixture]
    public class ProbabilitySpace2dTesOverallShape
    {
        private ProbabilitySpace2d ps1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCorrectDominanceWithExp1Supremacy()
        {
            this.ps1 = new ProbabilitySpace2d(3.1, 2.1, 13);

            double pL = ps1.AggregateLower();
            double pU = ps1.AggregateUpper();
            double pD = ps1.AggregateDiagonal();

            Assert.Greater(pL, pU);
            Assert.Greater(pL, pD);
            Assert.Greater(pU, pD);
        }

        [Test]
        public void TestCorrectDominanceWithExp2Supremacy()
        {
            this.ps1 = new ProbabilitySpace2d(2.1, 3.1, 13);

            double pL = ps1.AggregateLower();
            double pU = ps1.AggregateUpper();
            double pD = ps1.AggregateDiagonal();

            Assert.Greater(pU, pL);
            Assert.Greater(pL, pD);
            Assert.Greater(pU, pD);
        }

        [Test]
        public void TestCorrectDominanceWithNoSupremacy()
        {
            this.ps1 = new ProbabilitySpace2d(2.1, 2.1, 13);

            double pL = ps1.AggregateLower();
            double pU = ps1.AggregateUpper();
            double pD = ps1.AggregateDiagonal();

            Assert.AreEqual(pU, pL);
            Assert.Greater(pU, pD);
            Assert.Greater(pL, pD);
        }
    }
}