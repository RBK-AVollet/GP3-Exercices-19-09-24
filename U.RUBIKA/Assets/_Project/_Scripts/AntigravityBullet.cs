using System.Collections.Generic;
using Padrox.Acelab.Modules.Audio;
using UnityEngine;
using MEC;

namespace Rubika {
    public class AntigravityBullet : Bullet {
        [SerializeField] float _antigravityDuration = 1f;
        [SerializeField] SoundData _hitSound;
        
        public override void OnCollisionEnter(Collision other) {
            if (other.rigidbody) {
                Timing.RunCoroutine(ApplyAntigravity(other.rigidbody));
                other.rigidbody.AddForce(Random.insideUnitSphere * _damage, ForceMode.Impulse);

                SoundController.Instance.CreateSound()
                    .WithSoundData(_hitSound)
                    .WithPosition(other.GetContact(0).point)
                    .WithRandomPitch()
                    .Play();
            }
            
            Destroy(gameObject);
        }

        IEnumerator<float> ApplyAntigravity(Rigidbody rb) {
            rb.useGravity = false;
            yield return Timing.WaitForSeconds(_antigravityDuration);
            rb.useGravity = true;
        }
    }
}
