using UnityEngine;

namespace Rubika {
    [CreateAssetMenu(menuName = "Rubika/Weapon Data", fileName = "New Weapon Data")]
    public class WeaponData : ScriptableObject {
        public string weaponName;
        [TextArea] public string description;
        public float attackRatePerSecond = 1f;
        public Bullet bulletPrefab;
    }
}