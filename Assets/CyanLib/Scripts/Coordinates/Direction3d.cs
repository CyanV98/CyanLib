using System;
using UnityEngine;

namespace CyanLib.Coordinates
{
    /// <summary>
    ///     Represents a 3D direction vector with components clamped between -1 and 1.
    /// </summary>
    public readonly struct Direction3d : IEquatable<Direction3d>
    {
        public readonly int X;
        public readonly int Y;
        public readonly int Z;

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction3d" /> struct with specified X, Y, and Z values.
        /// </summary>
        /// <param name="x">The X component of the direction.</param>
        /// <param name="y">The Y component of the direction.</param>
        /// <param name="z">The Z component of the direction.</param>
        public Direction3d(int x, int y, int z)
        {
            X = Mathf.Clamp(x, -1, 1);
            Y = Mathf.Clamp(y, -1, 1);
            Z = Mathf.Clamp(z, -1, 1);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction3d" /> struct from a <see cref="Vector3Int" />.
        /// </summary>
        /// <param name="vector">The vector to convert.</param>
        public Direction3d(Vector3Int vector)
        {
            X = Mathf.Clamp(vector.x, -1, 1);
            Y = Mathf.Clamp(vector.y, -1, 1);
            Z = Mathf.Clamp(vector.z, -1, 1);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Direction3d" /> struct from a <see cref="Coordinates3d" />.
        /// </summary>
        /// <param name="coordinates">The coordinates to convert.</param>
        public Direction3d(Coordinates3d coordinates)
        {
            X = Mathf.Clamp(coordinates.X, -1, 1);
            Y = Mathf.Clamp(coordinates.Y, -1, 1);
            Z = Mathf.Clamp(coordinates.Z, -1, 1);
        }

        private static readonly Direction3d ZeroDirection = new(0, 0, 0);
        private static readonly Direction3d ForwardDirection = new(0, 0, 1);
        private static readonly Direction3d BackwardDirection = new(0, 0, -1);
        private static readonly Direction3d UpDirection = new(0, 1, 0);
        private static readonly Direction3d DownDirection = new(0, -1, 0);
        private static readonly Direction3d LeftDirection = new(-1, 0, 0);
        private static readonly Direction3d RightDirection = new(1, 0, 0);
        private static readonly Direction3d ForwardUpDirection = new(0, 1, 1);
        private static readonly Direction3d ForwardDownDirection = new(0, -1, 1);
        private static readonly Direction3d BackwardUpDirection = new(0, 1, -1);
        private static readonly Direction3d BackwardDownDirection = new(0, -1, -1);
        private static readonly Direction3d LeftUpDirection = new(-1, 1, 0);
        private static readonly Direction3d LeftDownDirection = new(-1, -1, 0);
        private static readonly Direction3d RightUpDirection = new(1, 1, 0);
        private static readonly Direction3d RightDownDirection = new(1, -1, 0);
        private static readonly Direction3d ForwardLeftDirection = new(-1, 0, 1);
        private static readonly Direction3d ForwardRightDirection = new(1, 0, 1);
        private static readonly Direction3d BackwardLeftDirection = new(-1, 0, -1);
        private static readonly Direction3d BackwardRightDirection = new(1, 0, -1);

        #endregion

        #region Operators

        public static Direction3d operator +(Direction3d a, Direction3d b)
        {
            return new Direction3d(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Direction3d operator -(Direction3d a, Direction3d b)
        {
            return new Direction3d(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static bool operator ==(Direction3d a, Direction3d b)
        {
            return a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        }

        public static bool operator !=(Direction3d a, Direction3d b)
        {
            return !(a == b);
        }

        public static implicit operator Vector3Int(Direction3d direction)
        {
            return new Vector3Int(direction.X, direction.Y, direction.Z);
        }

        public static implicit operator Direction3d(Vector3Int vector)
        {
            return new Direction3d(vector);
        }

        public static implicit operator Direction3d(Coordinates3d coordinates)
        {
            return new Direction3d(coordinates);
        }

        public static implicit operator Coordinates3d(Direction3d direction)
        {
            return new Coordinates3d(direction.X, direction.Y, direction.Z);
        }

        #endregion

        #region Public

        /// <summary>
        ///     Checks if the current <see cref="Direction3d" /> is equal to another <see cref="Direction3d" />.
        /// </summary>
        /// <param name="other">The other direction to compare.</param>
        /// <returns><c>true</c> if the directions are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Direction3d other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is Direction3d other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }

        public override string ToString()
        {
            return $"({X}, {Y}, {Z})";
        }

        #endregion
    }
}