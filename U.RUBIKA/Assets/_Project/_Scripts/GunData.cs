using UnityEngine;
using UnityEngine.Serialization;

namespace Rubika {
    [CreateAssetMenu(menuName = "Rubika/Weapon Data", fileName = "New Weapon Data")]
    public class GunData : ScriptableObject {
        public string weaponName;
        [TextArea] public string description;
        [Tooltip("Bullets per second")] public float fireRate = 1f;
        public float damage = 1f;
        public Bullet bulletPrefab;
    }
}