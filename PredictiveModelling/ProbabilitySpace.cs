using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra;
using System;

namespace PredictiveModelling
{
    public class ProbabilitySpace2d
    {
        /// <summary>
        /// A 2d Matrix of probabilities normalized to 1.
        /// </summary>
        private readonly Matrix<double> _space;

        /// <summary>
        /// Constructor
        /// <param name="exp1">Expected value for variable 1 (i.e. team / player)</param>
        /// <param name="exp1">Expected value for variable 2 (i.e. team / player)</param>
        /// <param name="dim">Maximum dimension of the space (i.e. 13 to produce a 13 x 13 space)</param>
        /// </summary>
        public ProbabilitySpace2d(double exp1, double exp2, int dim)
        {
            Matrix<double> ps = Matrix<double>.Build.Dense(dim, dim, (i, j) => Poisson.PMF(exp1, i) * Poisson.PMF(exp2, j));
            var Probs = ps.Enumerate();

            // Normalize to ensure sum(P) = 1
            double sum = 0;
            foreach (double prob in Probs) sum += prob;
            ps.MapInplace(e => e / sum);

            this._space = ps;
        }

        /// <summary>
        /// Aggregated probability for all outcomes where o1 > o2.
        /// </summary>
        public double AggregateLower()
        {
            Matrix<double> outcomes = this._space.StrictlyLowerTriangle();
            var Probs = outcomes.Enumerate();

            double sum = 0;
            foreach (double prob in Probs) sum += prob;

            return sum;
        }

        /// <summary>
        /// Aggregated probability for all outcomes where o2 > o1.
        /// </summary>
        public double AggregateUpper()
        {
            Matrix<double> outcomes = this._space.StrictlyUpperTriangle();
            var Probs = outcomes.Enumerate();

            double sum = 0;
            foreach (double prob in Probs) sum += prob;

            return sum;
        }

        /// <summary>
        /// Aggregated probability for all outcomes where o1 == o2.
        /// </summary>
        public double AggregateDiagonal()
        {
            Vector<double> mkts = this._space.Diagonal();
            var Probs = mkts.Enumerate();

            double sum = 0;
            foreach (double prob in Probs) sum += prob;

            return sum;
        }
    }
}
