using Padrox.Acelab.Modules.Audio;
using UnityEngine;

namespace Rubika {
    public class DoubleBarrelShotgun : Gun {
        [Header("References")]
        [SerializeField]
        [Tooltip("The left and right fire points of the shotgun.")]
        Transform[] _firePoints = new Transform[2];

        [SerializeField] SoundData _shootSound;
        
        public override void Shoot() {
            for (int i = 0; i < _firePoints.Length; i++) {
                Vector3 dir = _manager.GetShootDirFromFirePoint(_firePoints[i]);
                var bullet = Instantiate(_gunData.bulletPrefab, _firePoints[i].position, Quaternion.identity);
                bullet.Initialize(dir, _gunData.damage);
            }

            SoundController.Instance.CreateSound()
                .WithSoundData(_shootSound)
                .WithRandomPitch()
                .WithPosition(_firePoints[0].position)
                .Play();
        }
    }
}