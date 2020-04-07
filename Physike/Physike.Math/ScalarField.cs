using System;
using System.Collections.Generic;
using System.Text;

namespace Physike.Math
{
    /// <summary>
    /// A structure encapsulating a scalar field in three-dimensional Cartesian space.
    /// </summary>
    public struct ScalarField //: IEquatable<ScalarField>, IFormattable 
    {
        #region Public Fields

        public List<double> Points { get; }

        public double[] RangeX { get; }

        public double DeltaX { get; }

        public double[] RangeY { get; }

        public double DeltaY { get; }

        public double[] RangeZ { get; }

        public double DeltaZ { get; }

        #endregion

        #region Public Static Properties



        #endregion

        #region Public Constructors

        public ScalarField(double[] range, double delta)
        {
            RangeX = RangeY = RangeZ = range;
            DeltaX = DeltaY = DeltaZ = delta;
            Points = new List<double> { };
        }

        #endregion
    }
}