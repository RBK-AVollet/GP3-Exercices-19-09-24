using UnityEngine;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.CustomAttributes;
#endif

namespace Padrox.Acelab.Core
{
    public abstract class ControllerBase<T> : PersistentSingleton<T> where T : Component {
#if ODIN_INSPECTOR
        [PropertyOrder(10)]
        [BoxGroup("Controller")]
        [ToggleButtons]
#endif
        public bool debug;

        #region Unity Functions

        protected override void Awake() {
            base.Awake();
            Configure();
        }

        protected virtual void OnDisable() {
            Dispose();
        }

        #endregion

        #region Private Functions

        protected virtual void Configure() { }
        protected virtual void Dispose() { }

        protected virtual void Log(string msg) {
            if (!debug) return;
            Debug.Log($"[{GetName()}]: {msg}");
        }

        protected virtual void LogWarning(string msg) {
            if (!debug) return;
            Debug.LogWarning($"[{GetName()}]: {msg}");
        }

        protected virtual void LogError(string msg) {
            if (!debug) return;
            Debug.LogError($"[{GetName()}]: {msg}");
        }

        protected string GetName() => GetType().Name;

        #endregion
    }
}