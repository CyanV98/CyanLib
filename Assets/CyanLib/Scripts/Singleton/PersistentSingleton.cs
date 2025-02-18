using UnityEngine;

namespace CyanLib
{
    public class PersistentSingleton<T> : MonoBehaviour where T : Component
    {
        protected static T instance;
        public bool AutoUnparentOnAwake = true;

        public static bool HasInstance => instance != null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindAnyObjectByType<T>();
                    if (instance == null)
                    {
                        GameObject go = new(typeof(T).Name + " Auto-Generated");
                        instance = go.AddComponent<T>();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        ///     Make sure to call base.Awake() in override if you need awake.
        /// </summary>
        protected virtual void Awake()
        {
            InitializeSingleton();
        }

        public static T TryGetInstance()
        {
            return HasInstance ? instance : null;
        }

        protected virtual void InitializeSingleton()
        {
            if (!Application.isPlaying) return;

            if (AutoUnparentOnAwake) transform.SetParent(null);

            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instance != this) Destroy(gameObject);
            }
        }
    }
}