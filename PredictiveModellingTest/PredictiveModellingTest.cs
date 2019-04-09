using Xunit;
using PredictiveModelling;

namespace PrectiveModellingTest
{
    public class ShapeWithP1Supremacy
    {
        private readonly ProbabilitySpace2d ps1;
        private readonly double pL;
        private readonly double pU;
        private readonly double pD;

        public ShapeWithP1Supremacy()
        {
            ps1 = new ProbabilitySpace2d(3.1, 2.1, 13);

            pL = ps1.AggregateLower();
            pU = ps1.AggregateUpper();
            pD = ps1.AggregateDiagonal();

        }

        [Fact]
        public void TestCorrectDominanceWithP1Supremacy()
        {
            Assert.True(pL > pU);
            Assert.True(pL > pD);
            Assert.True(pU > pD);
        }
    }

    public class ShapeWithP2Supremacy
    {
        private readonly ProbabilitySpace2d ps1;
        private readonly double pL;
        private readonly double pU;
        private readonly double pD;

        public ShapeWithP2Supremacy()
        {
            ps1 = new ProbabilitySpace2d(2.1, 3.1, 13);

            pL = ps1.AggregateLower();
            pU = ps1.AggregateUpper();
            pD = ps1.AggregateDiagonal();
        }

        [Fact]
        public void TestCorrectDominanceWithP2Supremacy()
        {
            Assert.True(pL < pU);
            Assert.True(pL > pD);
            Assert.True(pU > pD);
        }
    }
}