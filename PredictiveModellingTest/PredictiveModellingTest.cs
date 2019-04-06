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
            this.ps1 = new ProbabilitySpace2d(3.1, 2.1, 13);
            this.pL = this.ps1.AggregateLower();
            this.pU = this.ps1.AggregateUpper();
            this.pD = this.ps1.AggregateDiagonal();
        }

        [Fact]
        public void TestCorrectDominanceWithP1Supremacy()
        {
            Assert.True(this.pL > this.pU);
            Assert.True(this.pL > this.pD);
            Assert.True(this.pU > this.pD);
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
            this.ps1 = new ProbabilitySpace2d(2.1, 3.2, 13);
            this.pL = this.ps1.AggregateLower();
            this.pU = this.ps1.AggregateUpper();
            this.pD = this.ps1.AggregateDiagonal();
        }


        [Fact]
        public void TestCorrectDominanceWithP2Supremacy()
        {
            Assert.True(this.pL < this.pU);
            Assert.True(this.pL > this.pD);
            Assert.True(this.pU > this.pD);
        }
    }    
}