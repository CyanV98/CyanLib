using UnityEngine;

namespace CyanLib.Coordinates
{
    public static class Vector2Extensions
    {
        /// <summary>
        ///     Adds to any <see cref="Coordinates2d" /> values of a <see cref="Vector2" />.
        /// </summary>
        public static Vector2 Add(this Vector2 vector2, Coordinates2d coordinates)
        {
            return new Vector2(vector2.x + coordinates.X, vector2.y + coordinates.Y);
        }

        /// <summary>
        ///     Adds to any <see cref="Direction2d" /> values of a <see cref="Vector2" />.
        /// </summary>
        public static Vector2 Add(this Vector2 vector2, Direction2d direction)
        {
            return new Vector2(vector2.x + direction.X, vector2.y + direction.Y);
        }
    }
}