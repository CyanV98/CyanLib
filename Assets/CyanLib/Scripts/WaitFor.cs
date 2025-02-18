using System.Collections.Generic;
using UnityEngine;

public static class WaitFor
{
    private static readonly Dictionary<float, WaitForSeconds> WaitForSecondsDict = new(100, new FloatComparer());
    public static WaitForFixedUpdate FixedUpdate { get; } = new();

    public static WaitForEndOfFrame EndOfFrame { get; } = new();

    public static WaitForSeconds Seconds(float seconds)
    {
        if (seconds < 1f / Application.targetFrameRate) return null;
        if (!WaitForSecondsDict.TryGetValue(seconds, out WaitForSeconds forSeconds))
        {
            forSeconds = new WaitForSeconds(seconds);
            WaitForSecondsDict[seconds] = forSeconds;
        }

        return forSeconds;
    }

    private class FloatComparer : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return Mathf.Abs(x - y) <= Mathf.Epsilon;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }
}