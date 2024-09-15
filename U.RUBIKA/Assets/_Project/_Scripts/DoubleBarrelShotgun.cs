using Padrox.Acelab.Modules.Audio;
using UnityEngine;

namespace Rubika {
    public class DoubleBarrelShotgun : Weapon {
        [Header("References")]
        [SerializeField]
        [Tooltip("The left and right fire points of the shotgun.")]
        Transform[] _firePoints = new Transform[2];

        [SerializeField] SoundData _shootSound;
        
        public override void Fire() {
            for (int i = 0; i < _firePoints.Length; i++) {
                Vector3 dir = _manager.GetShootDirFromFirePoint(_firePoints[i]);
                var bullet = Instantiate(_weaponData.bulletPrefab, _firePoints[i].position, Quaternion.identity);
                bullet.Initialize(dir);
            }

            SoundController.Instance.CreateSound()
                .WithSoundData(_shootSound)
                .WithRandomPitch()
                .WithPosition(_firePoints[0].position)
                .Play();
        }
    }
}