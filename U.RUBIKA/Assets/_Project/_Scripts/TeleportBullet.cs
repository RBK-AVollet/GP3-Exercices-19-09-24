using Padrox.Acelab.Modules.Audio;
using UnityEngine;

namespace Rubika {
    public class TeleportBullet : Bullet {
        [SerializeField] SoundData _hitSound;
        
        public override void OnCollisionEnter(Collision other)
        {
            if (other.rigidbody)
            {
                other.rigidbody.position = Random.insideUnitSphere * _damage;

                SoundController.Instance.CreateSound()
                    .WithSoundData(_hitSound)
                    .WithPosition(other.GetContact(0).point)
                    .WithRandomPitch()
                    .Play();
            }
            
            Destroy(gameObject);
        }
    }
}
