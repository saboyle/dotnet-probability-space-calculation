using PredictiveModelling;
using NUnit.Framework;

namespace PrectiveModellingTest
{
    [TestFixture]
    public class ShapeWithP1SupremacyN
    {
        private readonly ProbabilitySpace2d ps1;
        private readonly double pL;
        private readonly double pU;
        private readonly double pD;

        public ShapeWithP1SupremacyN()
        {
            ps1 = new ProbabilitySpace2d(3.1, 2.1, 13);

            pL = ps1.AggregateLower();
            pU = ps1.AggregateUpper();
            pD = ps1.AggregateDiagonal();

        }

        [Test]
        public void TestCorrectDominanceWithP1SupremacyN()
        {
            Assert.True(pL > pU);
            Assert.True(pL > pD);
            Assert.True(pU > pD);
        }
    }

    [TestFixture]
    public class ShapeWithP2SupremacyN
    {
        private readonly ProbabilitySpace2d ps1;
        private readonly double pL;
        private readonly double pU;
        private readonly double pD;

        public ShapeWithP2SupremacyN()
        {
            ps1 = new ProbabilitySpace2d(2.1, 3.1, 13);

            pL = ps1.AggregateLower();
            pU = ps1.AggregateUpper();
            pD = ps1.AggregateDiagonal();
        }

        [Test]
        public void TestCorrectDominanceWithP2SupremacyN()
        {
            Assert.True(pL < pU);
            Assert.True(pL > pD);
            Assert.True(pU > pD);
        }
    }
}