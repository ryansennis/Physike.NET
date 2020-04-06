using System;
using System.Globalization;
using System.Text;
using Physike.Math;

namespace Physike
{
    /// <summary>
    /// A class that represents a point particle.
    /// </summary>
    public class Particle : IEquatable<Particle>, IFormattable
    {
        #region Public Fields

        /// <summary>
        /// The <see cref="string"/> name of the particle.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The <see cref="Vector"/> position of the particle in Cartestian space.
        /// </summary>
        public Vector Position { get; }

        /// <summary>
        /// The <see cref="Vector"/> velocity of the particle in Cartestian space.
        /// </summary>
        public Vector Velocity { get; }

        /// <summary>
        /// The <see cref="double"/> mass of the particle in kilograms.
        /// </summary>
        public double Mass { get; }

        /// <summary>
        /// The <see cref="double"/> electric charge of the particle in Coulombs.
        /// </summary>
        public double Charge { get; }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Constructs a <see cref="Particle"/> with the given parameters.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="position">The initial position.</param>
        /// <param name="velocity">The initial velocity.</param>
        /// <param name="mass">The mass.</param>
        /// <param name="charge">The charge</param>
        public Particle(string name, Vector position, Vector velocity, double mass, double charge)
        {
            Name = name;
            Position = position;
            Velocity = velocity;
            Mass = mass;
            Charge = charge;
        }

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
            return Position.GetHashCode() + Mass.GetHashCode();
        }

        /// <summary>
        /// Gets a <see cref="string"/> representation of this <see cref="Vector"/> instance.
        /// </summary>
        /// <returns>The <see cref="string"/> representation.</returns>
        public override string ToString() => ToString("G", CultureInfo.CurrentCulture);

        #endregion

        #region Inheritance Methods

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Particle"/>.
        /// </summary>
        /// <param name="other">The <see cref="Particle"/> to compare.</param>
        /// <returns><see cref="true"/> if the instances are equal; <see cref="false"/> otherwise.</returns>
        public bool Equals(Particle other)
        {
            return Name == other.Name && // if instance position == other position and
                   Position == other.Position && // if instance mass == other mass and
                   Velocity == other.Velocity && // if instance velocity == other velocity and
                   Mass == other.Mass && // instance name == other name and
                   Charge == other.Charge; // instance charge == other charge the particles are the same particle and true is returned. Else returns false.
        }

        /// <summary>
        /// Gets a <see cref="string"/> representing this <see cref="Particle"/> using the specified format and
        /// <see cref="IFormatProvider"/> to format the <see cref="string"/>.
        /// </summary>
        /// <param name="format">The format of the individual elements.</param>
        /// <param name="formatProvider">The format provider to use when formatting the elements.</param>
        /// <returns>The <see cref="string"/> representation.</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            StringBuilder sb = new StringBuilder();
            string seperator = NumberFormatInfo.GetInstance(formatProvider).NumberGroupSeparator;
            sb.Append("Particle: ");
            sb.Append('(');
            sb.Append($"Name = {Name}");
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append($"r = {Position.ToString(format, formatProvider)}");
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append($"v = {Velocity.ToString(format, formatProvider)}");
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append($"Mass = {Mass.ToString(format, formatProvider)} kg");
            sb.Append(seperator);
            sb.Append(' ');
            sb.Append($"q = {Charge.ToString(format, formatProvider)} C");
            sb.Append(')');
            return sb.ToString();
        }

        #endregion
    }
}
