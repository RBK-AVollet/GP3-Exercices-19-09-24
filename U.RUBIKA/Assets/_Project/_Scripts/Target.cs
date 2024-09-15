using Padrox.Acelab.Modules.Audio;
using UnityEngine;

namespace Rubika
{
    public class Target : MonoBehaviour, IDamageable {
        [SerializeField] SoundData _deathSound;
        
        public float MaxHealth { get; }
        public float CurrentHealth { get; protected set; }
        
        public void TakeDamage(float damage) {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0) {
                Die();
            }
        }

        public void Die() {
            SoundController.Instance.CreateSound()
                .WithSoundData(_deathSound)
                .WithPosition(transform.position)
                .WithRandomPitch()
                .Play();
            
            Destroy(gameObject);
        }
    }
}
