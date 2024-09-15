using Padrox.Acelab.Modules.Audio;
using UnityEngine;

namespace Rubika
{
    public class AntigravityGun : Gun {
        [Header("References")]
        [SerializeField] Transform _firePoint;
        [SerializeField] SoundData _shootSound;
        
        public override void Shoot() {
            Vector3 dir = _manager.GetShootDirFromFirePoint(_firePoint);
            var bullet = Instantiate(_gunData.bulletPrefab, _firePoint.position, Quaternion.identity);
            bullet.Initialize(dir, _gunData.damage);

            SoundController.Instance.CreateSound()
                .WithSoundData(_shootSound)
                .WithRandomPitch()
                .WithPosition(_firePoint.position)
                .Play();
        }
    }
}
