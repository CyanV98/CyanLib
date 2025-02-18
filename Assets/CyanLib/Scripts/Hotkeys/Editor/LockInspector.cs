using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace CyanLib.Hotkeys
{
    public static class LockInspector {
        private static readonly MethodInfo FlipLocked;
        private static readonly PropertyInfo ConstrainProportions;
        private const BindingFlags BINDING_FLAGS = BindingFlags.NonPublic | BindingFlags.Instance;

        static LockInspector() {
            // Cache static MethodInfo and PropertyInfo for performance
#if UNITY_2023_2_OR_NEWER
            var editorLockTrackerType = typeof(EditorGUIUtility).Assembly.GetType("UnityEditor.EditorGUIUtility+EditorLockTracker");
            FlipLocked = editorLockTrackerType.GetMethod("FlipLocked", BINDING_FLAGS);
#endif
            ConstrainProportions = typeof(Transform).GetProperty("constrainProportionsScale", BINDING_FLAGS);
        }

        [MenuItem("Edit/Toggle Inspector Lock %l")]
        public static void Lock() {
#if UNITY_2023_2_OR_NEWER
            // New approach for Unity 2023.2 and above, including Unity 6
            var inspectorWindowType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.InspectorWindow");

            foreach (var inspectorWindow in Resources.FindObjectsOfTypeAll(inspectorWindowType)) {
                var lockTracker = inspectorWindowType.GetField("m_LockTracker", BINDING_FLAGS)
                    ?.GetValue(inspectorWindow);
                FlipLocked?.Invoke(lockTracker, new object[] { });
            }
#else
        // Old approach for Unity versions before 2023.2
        ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
#endif

            // Constrain Proportions lock for all versions including Unity 6
            foreach (var activeEditor in ActiveEditorTracker.sharedTracker.activeEditors) {
                if (activeEditor.target is not Transform target) continue;

                var currentValue = (bool) ConstrainProportions.GetValue(target, null);
                ConstrainProportions.SetValue(target, !currentValue, null);
            }

            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }

        [MenuItem("Edit/Toggle Inspector Lock %l", true)]
        public static bool Valid() {
            return ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
        }
    }
}
