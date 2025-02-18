using UnityEngine;

namespace CyanLib.Coordinates
{
    public static class Vector3Extensions
    {
        /// <summary>
        ///     Adds to any <see cref="Coordinates3d" /> values of a <see cref="Vector3" />.
        /// </summary>
        public static Vector3 Add(this Vector3 vector, Coordinates3d coordinates)
        {
            return new Vector3(vector.x + coordinates.X, vector.y + coordinates.Y, vector.z + coordinates.Z);
        }

        /// <summary>
        ///     Adds to any <see cref="Direction3d" /> values of a <see cref="Vector3" />.
        /// </summary>
        public static Vector3 Add(this Vector3 vector, Direction3d direction)
        {
            return new Vector3(vector.x + direction.X, vector.y + direction.Y, vector.z + direction.Z);
        }
    }
}