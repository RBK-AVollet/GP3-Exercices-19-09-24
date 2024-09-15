using UnityEngine;

namespace Rubika {
    public abstract class Gun : MonoBehaviour {
        [Header("Attributes")]
        [SerializeField] protected GunData _gunData;

        protected GunManager _manager;

        public GunData GunData => _gunData;
        
        public virtual void SetManager(GunManager manager) => _manager = manager;

        public abstract void Shoot();
    }
}