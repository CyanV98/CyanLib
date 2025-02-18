using System;
using UnityEngine;

namespace CyanLib.Coordinates
{
    /// <summary>
    ///     Represents an 8-directional vector in 2D space.
    /// </summary>
    public readonly struct Direction2d : IEquatable<Direction2d>
    {
        public readonly int X;
        public readonly int Y;

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction2d" /> struct with specified X and Y values.
        /// </summary>
        /// <param name="x">The X component of the direction.</param>
        /// <param name="y">The Y component of the direction.</param>
        public Direction2d(int x, int y)
        {
            X = Mathf.Clamp(x, -1, 1);
            Y = Mathf.Clamp(y, -1, 1);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction2d" /> struct from a <see cref="Vector2Int" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Direction2d(Vector2Int vector)
        {
            X = Mathf.Clamp(vector.x, -1, 1);
            Y = Mathf.Clamp(vector.y, -1, 1);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction2d" /> struct from a <see cref="Coordinates2d" />.
        /// </summary>
        /// <param name="coordinates">The coordinates to convert.</param>
        public Direction2d(Coordinates2d coordinates)
        {
            X = Mathf.Clamp(coordinates.X, -1, 1);
            Y = Mathf.Clamp(coordinates.Y, -1, 1);
        }

        private static readonly Direction2d ZeroDirection = new(0, 0);
        private static readonly Direction2d UpDirection = new(0, 1);
        private static readonly Direction2d DownDirection = new(0, -1);
        private static readonly Direction2d LeftDirection = new(-1, 0);
        private static readonly Direction2d RightDirection = new(1, 0);
        private static readonly Direction2d UpLeftDirection = new(-1, 1);
        private static readonly Direction2d UpRightDirection = new(1, 1);
        private static readonly Direction2d DownLeftDirection = new(-1, -1);
        private static readonly Direction2d DownRightDirection = new(1, -1);

        #endregion

        #region Operators

        public static Direction2d operator +(Direction2d a, Direction2d b)
        {
            return new Direction2d(a.X + b.X, a.Y + b.Y);
        }

        public static Direction2d operator -(Direction2d a, Direction2d b)
        {
            return new Direction2d(a.X - b.X, a.Y - b.Y);
        }

        public static bool operator ==(Direction2d a, Direction2d b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Direction2d a, Direction2d b)
        {
            return !(a == b);
        }

        public static implicit operator Vector2Int(Direction2d direction)
        {
            return new Vector2Int(direction.X, direction.Y);
        }

        public static implicit operator Direction2d(Vector2Int vector)
        {
            return new Direction2d(vector);
        }

        public static implicit operator Direction2d(Coordinates2d coordinates)
        {
            return new Direction2d(coordinates);
        }

        public static implicit operator Coordinates2d(Direction2d direction)
        {
            return new Coordinates2d(direction.X, direction.Y);
        }

        #endregion

        #region Public

        /// <summary>
        ///     Checks if the current <see cref="Direction2d" /> is equal to another <see cref="Direction2d" />.
        /// </summary>
        /// <param name="other">The other direction to compare.</param>
        /// <returns><c>true</c> if the directions are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Direction2d other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Direction2d other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        #endregion
    }
}