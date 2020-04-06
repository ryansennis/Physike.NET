using System;
using System.Globalization;
using System.Text;
using Util = System.Math;

namespace Physike.Math
{
    /// <summary>
    /// A structure encapsulating a three-dimensional vector.
    /// </summary>
    [Serializable]
    public struct Vector : IEquatable<Vector>, IFormattable
    {
        #region Public Fields

        /// <summary>
        /// The x-component of the <see cref="Vector"/>.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// The y-component of the <see cref="Vector"/>.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// The z-component of the <see cref="Vector"/>.
        /// </summary>
        public double Z { get; }

        #endregion

        #region Public Static Properties

        /// <summary>
        /// Returns a <see cref="Vector"/> with components (0, 0, 0).
        /// </summary>
        public static Vector Zero { get; } = new Vector(0d);
        /// <summary>
        /// Returns a <see cref="Vector"/> with components (1, 1, 1).
        /// </summary>
        public static Vector Identity { get; } = new Vector(1d);
        /// <summary>
        /// Returns a <see cref="Vector"/> with components (1, 0, 0).
        /// </summary>
        public static Vector I { get; } = new Vector(1d, 0d, 0d);
        /// <summary>
        /// Returns a <see cref="Vector"/> with components (0, 1, 0).
        /// </summary>
        public static Vector J { get; } = new Vector(0d, 1d, 0d);
        /// <summary>
        /// Returns a <see cref="Vector"/> with components (0, 0, 1).
        /// </summary>
        public static Vector K { get; } = new Vector(0d, 0d, 1d);

        #endregion

        #region Public Constructors

        /// <summary>
        /// Constructs a <see cref="Vector"/> whose elements are all the same value.
        /// </summary>
        /// <param name="value">The value to fill the <see cref="Vector"/> with.</param>
        public Vector(double value) : this(value, value, value) { }

        /// <summary>
        /// Constructs a <see cref="Vector"/> with the given individual values.
        /// </summary>
        /// <param name="x">The x-component.</param>
        /// <param name="y">The y-component.</param>
        /// <param name="z">The z-component.</param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds another <see cref="Vector"/> to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Vector"/> to add.</param>
        /// <returns>The result of the <see cref="Vector"> addition.</returns>
        public Vector Add(Vector other) => new Vector(X + other.X, Y + other.Y, Z + other.Z);

        /// <summary>
        /// Computes to cross product between another <see cref="Vector"/> and this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Vector"/> to use in the computation.</param>
        /// <returns>The <see cref="Vector"/> cross product.</returns>
        public Vector Cross(Vector other) => new Vector(Y * other.Z - Z * other.Y,
                                                           -(X * other.Z - Z * other.X),
                                                           X * other.Y - Y * other.X);

        /// <summary>
        /// Computes the distance from another <see cref="Vector"/> to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Vector"/> to use in the computation.</param>
        /// <returns>The <see cref="double"/> distance result.</returns>
        public double Distance(Vector other) => Util.Sqrt(DistanceSquared(other));

        /// <summary>
        /// Computes the distance squared from another <see cref="Vector"/> to this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Vector"/> to use in the computation.</param>
        /// <returns>The <see cref="double"/> distance squared result.</returns>
        public double DistanceSquared(Vector other) => Util.Pow(other.X - X, 2) + Util.Pow(other.Y - Y, 2) + Util.Pow(other.Z - Z, 2);

        /// <summary>
        /// Divides this <see cref="Vector"/> by a scalar value.
        /// </summary>
        /// <param name="scalar">The <see cref="double"/> scalar to use.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar division.</returns>
        public Vector Divide(double scalar) => new Vector(X / scalar, Y / scalar, Z / scalar);

        /// <summary>
        /// Computes the <see cref="double"/> dot product between another <see cref="Vector"/> and this instance.
        /// </summary>
        /// <param name="other">The other <see cref="Vector"/> to use in the computation.</param>
        /// <returns>The <see cref="double"/> dot product result.</returns>
        public double Dot(Vector other) => X * other.X + Y * other.Y + Z * other.Z;

        /// <summary>
        /// Computes the length of this <see cref="Vector"/> instance.
        /// </summary>
        /// <returns>The <see cref="double"/> length of this <see cref="Vector"/>.</returns>
        public double Length() => Util.Sqrt(LengthSquared());

        /// <summary>
        /// Computes the length squared of this <see cref="Vector"/> instance.
        /// </summary>
        /// <returns>The <see cref="double"/> length squared of this <see cref="Vector"/>.</returns>
        public double LengthSquared() => DistanceSquared(Zero);

        /// <summary>
        /// Multiplies this <see cref="Vector"/> instance by a scalar.
        /// </summary>
        /// <param name="scalar">The <see cref="double"/> scalar to multiply by.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar multiplication.</returns>
        public Vector Multiply(double scalar) => new Vector(X * scalar, Y * scalar, Z * scalar);

        /// <summary>
        /// Reverses the sign of each element in this <see cref="Vector"/> instance.
        /// </summary>
        /// <returns>The negated <see cref="Vector"/>.</returns>
        public Vector Negate() => new Vector(-X, -Y, -Z);

        /// <summary>
        /// Gets a <see cref="Vector"/> pointing in the direction of this <see cref="Vector"/> instance with length = 1d.
        /// </summary>
        /// <returns>The unit <see cref="Vector"/>.</returns>
        public Vector Normalize() => Divide(Length());

        /// <summary>
        /// Subtracts another <see cref="Vector"/> from this instance.
        /// </summary>
        /// <param name="other">The <see cref="Vector"/> to subtract.</param>
        /// <returns>The <see cref="Vector"/> result of the subtraction.</returns>
        public Vector Subtract(Vector other) => new Vector(X - other.X, Y - other.Y, Z - other.Z);

        /// <summary>
        /// Gets a <see cref="string"/> representing this <see cref="Vector"/> using the specified format to format the individual elements.
        /// </summary>
        /// <param name="format">The format of the individual elements.</param>
        /// <returns>The <see cref="string"/> representation.</returns>
        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        #endregion

        #region Public Static Methods

        /// <summary>
        /// Adds two <see cref="Vector"/>s together.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="Vector"/> result of the addition.</returns>
        public static Vector Add(Vector left, Vector right) => left.Add(right);

        /// <summary>
        /// Computes the cross product between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="Vector"/> cross product.</returns>
        public static Vector Cross(Vector left, Vector right) => left.Cross(right);

        /// <summary>
        /// Computes the distance between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> distance.</returns>
        public static double Distance(Vector left, Vector right) => Util.Sqrt(DistanceSquared(left, right));

        /// <summary>
        /// Computes the distance squared between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> distance squared.</returns>
        public static double DistanceSquared(Vector left, Vector right) => left.DistanceSquared(right);

        /// <summary>
        /// Divides a <see cref="Vector"/> by a scalar.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to be divided.</param>
        /// <param name="scalar">The <see cref="double"/> scalar to divide by.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar division.</returns>
        public static Vector Divide(Vector vector, double scalar) => vector.Divide(scalar);

        /// <summary>
        /// Computes the dot product between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> dot product.</returns>
        public static double Dot(Vector left, Vector right) => left.Dot(right);

        /// <summary>
        /// Computes the length of a <see cref="Vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> length.</returns>
        public static double Length(Vector vector) => Util.Sqrt(LengthSquared(vector));

        /// <summary>
        /// Computes the length squared of a <see cref="Vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> length squared.</returns>
        public static double LengthSquared(Vector vector) => vector.LengthSquared();

        /// <summary>
        /// Multiplies two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="vector">The first <see cref="Vector"/>.</param>
        /// <param name="scalar">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar multiplication.</returns>
        public static Vector Multiply(Vector vector, double scalar) => vector.Multiply(scalar);

        /// <summary>
        /// Gets a <see cref="Vector"/> pointing in the direction of the given <see cref="Vector"/> instance with length = 1d.
        /// </summary>
        /// <returns>The unit <see cref="Vector"/>.</returns>
        public static Vector Normalize(Vector vector) => vector.Normalize();

        /// <summary>
        /// Reverses the sign of each element a <see cref="Vector"/>.
        /// </summary>
        /// <returns>The negated <see cref="Vector"/>.</returns>
        public static Vector Negate(Vector vector) => vector.Negate();

        /// <summary>
        /// Subtracts one <see cref="Vector"/> from another.
        /// </summary>
        /// <param name="left">The <see cref="Vector"/> to be subtracted from.</param>
        /// <param name="right">The <see cref="Vector"/> to subtract.</param>
        /// <returns>The <see cref="Vector"/> result of the subtraction.</returns>
        public static Vector Subtract(Vector left, Vector right) => left.Subtract(right);

        #endregion

        #region Override Methods

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <returns><see cref="true"/> if the instances are equal; <see cref="false"/> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return (obj is Vector) && // if obj is a vector and
                Equals((Vector)obj); // the vectors are equal true is returned
            // this calls the public bool Equals(Vector3 other) method implimented through IFormattable, located in the Inheritance Methods region
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Vector"/>.
        /// </summary>
        /// <returns>The hash code of this <see cref="Vector"/>.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }

        /// <summary>
        /// Gets a <see cref="string"/> representation of this <see cref="Vector"/> instance.
        /// </summary>
        /// <returns>The <see cref="string"/> representation.</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        #endregion

        #region Inheritance Methods

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Vector"/>.
        /// </summary>
        /// <param name="other">The <see cref="Vector"/> to compare.</param>
        /// <returns><see cref="true"/> if the instances are equal; <see cref="false"/> otherwise.</returns>
        public bool Equals(Vector other)
        {
            return X == other.X && // if instance x == other x and
                   Y == other.Y && // if instance y == other y and
                   Z == other.Z; // if instanc z == other z the vectors are equal and true is returned. Else false is returned
        }

        /// <summary>
        /// Gets a <see cref="string"/> representing this <see cref="Vector"/> using the specified format and
        /// <see cref="IFormatProvider"/> to format the <see cref="string"/>.
        /// </summary>
        /// <param name="format">The format of the individual elements.</param>
        /// <param name="formatProvider">The format provider to use when formatting the elements.</param>
        /// <returns>The <see cref="string"/> representation.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder(9);
            string seperator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append('<');
            sb.Append(X.ToString(format, formatProvider));
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append(Y.ToString(format, formatProvider));
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append(Z.ToString(format, formatProvider));
            sb.Append('>');
            return sb.ToString();
        }

        #endregion

        #region Public Static Operators

        /// <summary>
        /// Negates a <see cref="Vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to perform the unary negation operation on.</param>
        /// <returns>The <see cref="Vector"/> result of the unary negation operation.</returns>
        public static Vector operator -(Vector vector) => Negate(vector);

        /// <summary>
        /// Adds one to each element in a <see cref="Vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to perform the unary increment operation on.</param>
        /// <returns>The <see cref="Vector"/> result of the unary increment operation.</returns>
        public static Vector operator ++(Vector vector) => Add(vector, Identity);

        /// <summary>
        /// Subtracts one from each element in a <see cref="Vector"/>.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to perform the unary decrement operation on.</param>
        /// <returns>The <see cref="Vector"/> result of the unary decrement operation.</returns>
        public static Vector operator --(Vector vector) => Subtract(vector, Identity);

        /// <summary>
        /// Adds two <see cref="Vector"/>s together.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/> to use in the addition.</param>
        /// <param name="right">The second <see cref="Vector"/> to use in the addition.</param>
        /// <returns>The <see cref="Vector"/> result of the addition.</returns>
        public static Vector operator +(Vector left, Vector right) => Add(left, right);

        /// <summary>
        /// Subtracts one <see cref="Vector"/> from another.
        /// </summary>
        /// <param name="left">The <see cref="Vector"/> to be subtracted from.</param>
        /// <param name="right">The <see cref="Vector"/> to subtract.</param>
        /// <returns>The <see cref="Vector"/> result of the subtraction.</returns>
        public static Vector operator -(Vector left, Vector right) => Subtract(left, right);

        /// <summary>
        /// Multiplies two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to be multiplied.</param>
        /// <param name="scalar">The <see cref="double"/> scalar to multiply by.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar multiplication.</returns>
        public static Vector operator *(Vector vector, double scalar) => Multiply(vector, scalar);

        /// <summary>
        /// Multiplies two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="scalar">The <see cref="double"/> scalar to multiply by.</param>
        /// <param name="vector">The <see cref="Vector"/> to be multiplied.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar multiplication.</returns>
        public static Vector operator *(double scalar, Vector vector) => Multiply(vector, scalar);

        /// <summary>
        /// Divides a <see cref="Vector"/> by a scalar.
        /// </summary>
        /// <param name="vector">The <see cref="Vector"/> to be divided.</param>
        /// <param name="scalar">The <see cref="double"/> scalar to divide by.</param>
        /// <returns>The <see cref="Vector"/> result of the scalar division.</returns>
        public static Vector operator /(Vector vector, double scalar) => Divide(vector, scalar);

        /// <summary>
        /// Computes the dot product between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/>.</param>
        /// <param name="right">The second <see cref="Vector"/>.</param>
        /// <returns>The <see cref="double"/> dot product.</returns>
        public static double operator *(Vector left, Vector right) => Dot(left, right);

        /// <summary>
        /// Computes the cross product between two <see cref="Vector"/>s.
        /// </summary>
        /// <param name="left">The first <see cref="Vector"/> to use in the computation.</param>
        /// <param name="right">The second <see cref="Vector"/> to use in the computation.</param>
        /// <returns>The <see cref="Vector"/> cross product.</returns>
        public static Vector operator %(Vector left, Vector right) => Cross(left, right);

        /// <summary>
        /// Checks the equality of two <see cref="Vector"/>s.
        /// </summary>
        public static bool operator ==(Vector left, Vector right) => left.Equals(right);

        /// <summary>
        /// Checks the inequality of two <see cref="Vector"/>s.
        /// </summary>
        public static bool operator !=(Vector left, Vector right) => !left.Equals(right);

        /// <summary>
        /// Checks to see if a <see cref="Vector"/>'s length is greater than anothers.
        /// </summary>
        public static bool operator >(Vector left, Vector right) => left.LengthSquared() > right.LengthSquared();

        /// <summary>
        /// Checks to see if a <see cref="Vector"/>'s length is less than anothers.
        /// </summary>
        public static bool operator <(Vector left, Vector right) => left.LengthSquared() < right.LengthSquared();

        /// <summary>
        /// Checks to see if a <see cref="Vector"/>'s length is greater than or equal to anothers.
        /// </summary>
        public static bool operator >=(Vector left, Vector right) => left > right || left == right;

        /// <summary>
        /// Checks to see if a <see cref="Vector"/>'s length is less than or equal to anothers.
        /// </summary>
        public static bool operator <=(Vector left, Vector right) => left < right || left == right;

        #endregion

        #region Implicit Public Casting Operators

        /// <summary>
        /// Implicity casts a <see cref="ValueTuple{T1, T2, T3}"/> into a <see cref="Vector"/> with the x, y and z-component
        /// set by the <see cref="ValueTuple{T1, T2, T3}"/>.
        /// </summary>
        /// <param name="twoTuple">The <see cref="ValueTuple{T1, T2, T3}"/> to cast.</param>
        public static implicit operator Vector(ValueTuple<double, double, double> threeTuple)
            => new Vector(threeTuple.Item1, threeTuple.Item2, threeTuple.Item3);

        #endregion
    }
}
