using UnityEngine;

namespace Rubika {
    public abstract class Weapon : MonoBehaviour {
        [Header("Attributes")]
        [SerializeField] protected WeaponData _weaponData;

        protected WeaponManager _manager;

        public WeaponData WeaponData => _weaponData;
        
        public virtual void SetManager(WeaponManager manager) => _manager = manager;

        public abstract void Fire();
    }
}