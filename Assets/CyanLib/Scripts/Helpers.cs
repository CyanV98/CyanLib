using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CyanLib
{
    public static class Helpers
    {
        public static WaitForSeconds GetWaitForSeconds(float seconds)
        {
            return WaitFor.Seconds(seconds);
        }

        /// <summary>
        ///     Clears the console log in the Unity Editor.
        /// </summary
#if UNITY_EDITOR
        public static void ClearConsole()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(SceneView));
            Type type = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo method = type.GetMethod("Clear");
            method?.Invoke(new object(), null);
        }
#endif
    }
}