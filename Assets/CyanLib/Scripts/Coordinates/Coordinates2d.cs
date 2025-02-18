using System;
using UnityEngine;

namespace CyanLib.Coordinates
{
    /// <summary>
    ///     Represents a 2D coordinate with integer values.
    /// </summary>
    public struct Coordinates2d : IEquatable<Coordinates2d>
    {
        public int X;
        public int Y;

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates2d" /> struct with specified X and Y values.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Coordinates2d(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates2d" /> struct from a <see cref="Vector2" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Coordinates2d(Vector2 vector)
        {
            X = Mathf.FloorToInt(vector.x);
            Y = Mathf.FloorToInt(vector.y);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates2d" /> struct from a <see cref="Vector2Int" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Coordinates2d(Vector2Int vector)
        {
            X = vector.x;
            Y = vector.y;
        }

        private static readonly Coordinates2d ZeroCoordinates = new(0, 0);
        private static readonly Coordinates2d OneCoordinates = new(1, 1);
        private static readonly Coordinates2d UpCoordinates = new(0, 1);
        private static readonly Coordinates2d DownCoordinates = new(0, -1);
        private static readonly Coordinates2d LeftCoordinates = new(-1, 0);
        private static readonly Coordinates2d RightCoordinates = new(1, 0);
        private static readonly Coordinates2d MaxCoordinates = new(int.MaxValue, int.MaxValue);
        private static readonly Coordinates2d MinCoordinates = new(int.MinValue, int.MinValue);

        #endregion

        #region Operators

        public static Coordinates2d operator +(Coordinates2d a, Coordinates2d b)
        {
            return new Coordinates2d(a.X + b.X, a.Y + b.Y);
        }

        public static Coordinates2d operator -(Coordinates2d a, Coordinates2d b)
        {
            return new Coordinates2d(a.X - b.X, a.Y - b.Y);
        }

        public static Coordinates2d operator *(Coordinates2d a, int b)
        {
            return new Coordinates2d(a.X * b, a.Y * b);
        }

        public static Coordinates2d operator /(Coordinates2d a, int b)
        {
            return new Coordinates2d(a.X / b, a.Y / b);
        }

        public static Coordinates2d operator *(Coordinates2d a, Coordinates2d b)
        {
            return new Coordinates2d(a.X * b.X, a.Y * b.Y);
        }

        public static Coordinates2d operator /(Coordinates2d a, Coordinates2d b)
        {
            return new Coordinates2d(a.X / b.X, a.Y / b.Y);
        }

        public static Coordinates2d operator -(Coordinates2d a)
        {
            return new Coordinates2d(-a.X, -a.Y);
        }

        public static bool operator ==(Coordinates2d a, Coordinates2d b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Coordinates2d a, Coordinates2d b)
        {
            return !(a == b);
        }

        public static implicit operator Vector2(Coordinates2d coordinates)
        {
            return new Vector2(coordinates.X, coordinates.Y);
        }

        public static implicit operator Vector2Int(Coordinates2d coordinates)
        {
            return new Vector2Int(coordinates.X, coordinates.Y);
        }

        public static implicit operator Coordinates2d(Vector2 vector)
        {
            return new Coordinates2d(vector);
        }

        public static implicit operator Coordinates2d(Vector2Int vector)
        {
            return new Coordinates2d(vector);
        }

        #endregion

        #region Public

        /// <summary>
        ///     Converts the <see cref="Coordinates2d" /> to a <see cref="Vector2" />.
        /// </summary>
        /// <returns>A <see cref="Vector2" /> representation of the coordinate.</returns>
        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates2d" /> to a <see cref="Vector2Int" />.
        /// </summary>
        /// <returns>A <see cref="Vector2Int" /> representation of the coordinate.</returns>
        public Vector2Int ToVector2Int()
        {
            return new Vector2Int(X, Y);
        }

        /// <summary>
        ///     Clamps the coordinates within a specified range.
        /// </summary>
        /// <param name="minX">The minimum X value.</param>
        /// <param name="maxX">The maximum X value.</param>
        /// <param name="minY">The minimum Y value.</param>
        /// <param name="maxY">The maximum Y value.</param>
        /// <returns>The clamped coordinates.</returns>
        public Coordinates2d Clamp(int minX, int maxX, int minY, int maxY)
        {
            return new Coordinates2d(
                Mathf.Clamp(X, minX, maxX),
                Mathf.Clamp(Y, minY, maxY)
            );
        }

        /// <summary>
        ///     Checks if the coordinates are inside a specified rectangular area.
        /// </summary>
        /// <param name="minX">The minimum X value.</param>
        /// <param name="maxX">The maximum X value.</param>
        /// <param name="minY">The minimum Y value.</param>
        /// <param name="maxY">The maximum Y value.</param>
        /// <returns><c>true</c> if the coordinates are inside the area; otherwise, <c>false</c>.</returns>
        public bool IsInside(int minX, int maxX, int minY, int maxY)
        {
            return X >= minX && X <= maxX && Y >= minY && Y <= maxY;
        }

        /// <summary>
        ///     Calculates the distance to another <see cref="Coordinates2d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The distance between the two coordinates.</returns>
        public float DistanceTo(Coordinates2d other)
        {
            return Mathf.Sqrt(Mathf.Pow(X - other.X, 2) + Mathf.Pow(Y - other.Y, 2));
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates2d" /> to a horizontal <see cref="Coordinates3d" />.
        /// </summary>
        /// <returns>A <see cref="Coordinates3d" /> with the Z coordinate set to 0.</returns>
        public Coordinates3d ToCoordinates3dHorizontal()
        {
            return new Coordinates3d(X, 0, Y);
        }

        /// <summary>
        ///     Converts the <see cref="Coordinates2d" /> to a vertical <see cref="Coordinates3d" />.
        /// </summary>
        /// <returns>A <see cref="Coordinates3d" /> with the Y coordinate set to 0.</returns>
        public Coordinates3d ToCoordinates3dVertical()
        {
            return new Coordinates3d(X, Y, 0);
        }

        /// <summary>
        ///     Adds a <see cref="Direction2d" /> to the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to add.</param>
        /// <returns>The resulting coordinates after adding the direction.</returns>
        public Coordinates2d Add(Direction2d direction)
        {
            return new Coordinates2d(X + direction.X, Y + direction.Y);
        }

        /// <summary>
        ///     Subtracts a <see cref="Direction2d" /> from the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to subtract.</param>
        /// <returns>The resulting coordinates after subtracting the direction.</returns>
        public Coordinates2d Subtract(Direction2d direction)
        {
            return new Coordinates2d(X - direction.X, Y - direction.Y);
        }

        /// <summary>
        ///     Adds a multiple of a <see cref="Direction2d" /> to the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to multiply and add.</param>
        /// <param name="multiplier">The number of times to add the direction.</param>
        /// <returns>The resulting coordinates after adding the multiple of the direction.</returns>
        public Coordinates2d AddMultiple(Direction2d direction, int multiplier)
        {
            return new Coordinates2d(X + direction.X * multiplier, Y + direction.Y * multiplier);
        }

        /// <summary>
        ///     Subtracts a multiple of a <see cref="Direction2d" /> from the current coordinates.
        /// </summary>
        /// <param name="direction">The direction to multiply and subtract.</param>
        /// <param name="multiplier">The number of times to subtract the direction.</param>
        /// <returns>The resulting coordinates after subtracting the multiple of the direction.</returns>
        public Coordinates2d SubtractMultiple(Direction2d direction, int multiplier)
        {
            return new Coordinates2d(X - direction.X * multiplier, Y - direction.Y * multiplier);
        }

        /// <summary>
        ///     Calculates the angle from the current coordinates to another <see cref="Coordinates2d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The angle in degrees.</returns>
        public float AngleTo(Coordinates2d other)
        {
            return Mathf.Atan2(other.Y - Y, other.X - X) * Mathf.Rad2Deg;
        }

        /// <summary>
        ///     Calculates the direction from the current coordinates to another <see cref="Coordinates2d" />.
        /// </summary>
        /// <param name="other">The other coordinate.</param>
        /// <returns>The normalized direction as a <see cref="Vector2" />.</returns>
        public Vector2 DirectionTo(Coordinates2d other)
        {
            return (other - this).ToVector2().normalized;
        }

        public bool Equals(Coordinates2d other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Coordinates2d other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }

        #endregion
    }
}