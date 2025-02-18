using System;
using UnityEngine;

namespace CyanLib.Coordinates
{
    /// <summary>
    ///     Represents a 3D coordinate with integer values.
    /// </summary>
    public struct Coordinates3d : IEquatable<Coordinates3d>
    {
        public int X;
        public int Y;
        public int Z;

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates3d" /> struct with specified X, Y, and Z values.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        /// <param name="z">The Z coordinate.</param>
        public Coordinates3d(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates3d" /> struct from a <see cref="Vector3" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Coordinates3d(Vector3 vector)
        {
            X = Mathf.FloorToInt(vector.x);
            Y = Mathf.FloorToInt(vector.y);
            Z = Mathf.FloorToInt(vector.z);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates3d" /> struct from a <see cref="Vector3Int" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Coordinates3d(Vector3Int vector)
        {
            X = vector.x;
            Y = vector.y;
            Z = vector.z;
        }

        private static readonly Coordinates3d ZeroCoordinates = new(0, 0, 0);
        private static readonly Coordinates3d OneCoordinates = new(1, 1, 1);
        private static readonly Coordinates3d UpCoordinates = new(0, 1, 0);
        private static readonly Coordinates3d DownCoordinates = new(0, -1, 0);
        private static readonly Coordinates3d LeftCoordinates = new(-1, 0, 0);
        private static readonly Coordinates3d RightCoordinates = new(1, 0, 0);
        private static readonly Coordinates3d ForwardCoordinates = new(0, 0, 1);
        private static readonly Coordinates3d BackwardCoordinates = new(0, 0, -1);
        private static readonly Coordinates3d MaxCoordinates = new(int.MaxValue, int.MaxValue, int.MaxValue);
        private static readonly Coordinates3d MinCoordinates = new(int.MinValue, int.MinValue, int.MinValue);

        #endregion

        #region Operators

        public static Coordinates3d operator +(Coordinates3d a, Coordinates3d b)
        {
            return new Coordinates3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Coordinates3d operator -(Coordinates3d a, Coordinates3d b)
        {
            return new Coordinates3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Coordinates3d operator *(Coordinates3d a, int b)
        {
            return new Coordinates3d(a.X * b, a.Y * b, a.Z * b);
        }

        public static Coordinates3d operator /(Coordinates3d a, int b)
        {
            return new Coordinates3d(a.X / b, a.Y / b, a.Z / b);
        }

        public static Coordinates3d operator *(Coordinates3d a, Coordinates3d b)
        {
            return new Coordinates3d(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }

        public static Coordinates3d operator /(Coordinates3d a, Coordinates3d b)
        {
            return new Coordinates3d(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Coordinates3d operator -(Coordinates3d a)
        {
            return new Coordinates3d(-a.X, -a.Y, -a.Z);
        }

        public static bool operator ==(Coordinates3d a, Coordinates3d b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Coordinates3d a, Coordinates3d b)
        {
            return !(a == b);
        }

        public static implicit operator Vector3(Coordinates3d coordinates)
        {
            return new Vector3(coordinates.X, coordinates.Y, coordinates.Z);
        }

        public static implicit operator Vector3Int(Coordinates3d coordinates)
        {
            return new Vector3Int(coordinates.X, coordinates.Y, coordinates.Z);
        }

        public static implicit operator Coordinates3d(Vector3 vector)
        {
            return new Coordinates3d(vector);
        }

        public static implicit operator Coordinates3d(Vector3Int vector)
        {
            return new Coordinates3d(vector);
        }

        #endregion

        #region Public

        /// <summary>
        ///     Converts the <see cref="Coordinates3d" /> to a <see cref="Vector3" />.
        /// </summary>
        /// <returns>A <see cref="Vector3" /> representation of the coordinate.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates3d" /> to a <see cref="Vector3Int" />.
        /// </summary>
        /// <returns>A <see cref="Vector3Int" /> representation of the coordinate.</returns>
        public Vector3Int ToVector3Int()
        {
            return new Vector3Int(X, Y, Z);
        }

        /// <summary>
        ///     Clamps the coordinates within a specified range.
        /// </summary>
        /// <param name="minX">The minimum X value.</param>
        /// <param name="maxX">The maximum X value.</param>
        /// <param name="minY">The minimum Y value.</param>
        /// <param name="maxY">The maximum Y value.</param>
        /// <param name="minZ">The minimum Z value.</param>
        /// <param name="maxZ">The maximum Z value.</param>
        /// <returns>The clamped coordinates.</returns>
        public Coordinates3d Clamp(int minX, int maxX, int minY, int maxY, int minZ, int maxZ)
        {
            return new Coordinates3d(
                Mathf.Clamp(X, minX, maxX),
                Mathf.Clamp(Y, minY, maxY),
                Mathf.Clamp(Z, minZ, maxZ)
            );
        }

        /// <summary>
        ///     Checks if the coordinates are inside a specified cubic area.
        /// </summary>
        /// <param name="minX">The minimum X value.</param>
        /// <param name="maxX">The maximum X value.</param>
        /// <param name="minY">The minimum Y value.</param>
        /// <param name="maxY">The maximum Y value.</param>
        /// <param name="minZ">The minimum Z value.</param>
        /// <param name="maxZ">The maximum Z value.</param>
        /// <returns><c>true</c> if the coordinates are inside the area; otherwise, <c>false</c>.</returns>
        public bool IsInside(int minX, int maxX, int minY, int maxY, int minZ, int maxZ)
        {
            return X >= minX && X <= maxX && Y >= minY && Y <= maxY && Z >= minZ && Z <= maxZ;
        }

        /// <summary>
        ///     Calculates the distance to another <see cref="Coordinates3d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The distance between the two coordinates.</returns>
        public float DistanceTo(Coordinates3d other)
        {
            return Mathf.Sqrt(Mathf.Pow(X - other.X, 2) + Mathf.Pow(Y - other.Y, 2) + Mathf.Pow(Z - other.Z, 2));
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates3d" /> to a horizontal <see cref="Coordinates2d" />.
        /// </summary>
        /// <returns>A <see cref="Coordinates2d" /> with the Y coordinate set to 0.</returns>
        public Coordinates2d ToCoordinates2dHorizontal()
        {
            return new Coordinates2d(X, Z);
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates3d" /> to a vertical <see cref="Coordinates2d" />.
        /// </summary>
        /// <returns>A <see cref="Coordinates2d" /> with the Z coordinate set to 0.</returns>
        public Coordinates2d ToCoordinates2dVertical()
        {
            return new Coordinates2d(X, Y);
        }

        /// <summary>
        ///     Adds a <see cref="Direction3d" /> to the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to add.</param>
        /// <returns>The resulting coordinates after adding the direction.</returns>
        public Coordinates3d Add(Direction3d direction)
        {
            return new Coordinates3d(X + direction.X, Y + direction.Y, Z + direction.Z);
        }

        /// <summary>
        ///     Subtracts a <see cref="Direction3d" /> from the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to subtract.</param>
        /// <returns>The resulting coordinates after subtracting the direction.</returns>
        public Coordinates3d Subtract(Direction3d direction)
        {
            return new Coordinates3d(X - direction.X, Y - direction.Y, Z - direction.Z);
        }

        /// <summary>
        ///     Adds a multiple of a <see cref="Direction3d" /> to the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to multiply and add.</param>
        /// <param name="multiplier">The number of times to add the direction.</param>
        /// <returns>The resulting coordinates after adding the multiple of the direction.</returns>
        public Coordinates3d AddMultiple(Direction3d direction, int multiplier)
        {
            return new Coordinates3d(X + direction.X * multiplier, Y + direction.Y * multiplier,
                Z + direction.Z * multiplier);
        }

        /// <summary>
        ///     Subtracts a multiple of a <see cref="Direction3d" /> from the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to multiply and subtract.</param>
        /// <param name="multiplier">The number of times to subtract the direction.</param>
        /// <returns>The resulting coordinates after subtracting the multiple of the direction.</returns>
        public Coordinates3d SubtractMultiple(Direction3d direction, int multiplier)
        {
            return new Coordinates3d(X - direction.X * multiplier, Y - direction.Y * multiplier,
                Z - direction.Z * multiplier);
        }

        /// <summary>
        ///     Checks if the current <see cref="Coordinates3d" /> is equal to another <see cref="Coordinates3d" />.
        /// </summary>
        /// <param name="other">The other coordinate to compare.</param>
        /// <returns><c>true</c> if the coordinates are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Coordinates3d other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        ///     Calculates the angle from the current coordinates to another <see cref="Coordinates3d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The angle in degrees.</returns>
        public float AngleTo(Coordinates3d other)
        {
            return Mathf.Acos((X * other.X + Y * other.Y + Z * other.Z) / (Mathf.Sqrt(X * X + Y * Y + Z * Z) *
                                                                           Mathf.Sqrt(other.X * other.X +
                                                                               other.Y * other.Y +
                                                                               other.Z * other.Z))) * Mathf.Rad2Deg;
        }

        /// <summary>
        ///     Calculates the direction from the current coordinates to another <see cref="Coordinates3d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The normalized direction as a <see cref="Vector3" />.</returns>
        public Vector3 DirectionTo(Coordinates3d other)
        {
            return (other - this).ToVector3().normalized;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates3d other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Z}";
        }

        #endregion
    }
}