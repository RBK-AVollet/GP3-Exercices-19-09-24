using UnityEngine;

namespace Rubika {
    public class Bullet : MonoBehaviour {
        const float k_expirationDelay = 20f;

        [Header("Attributes")]
        [SerializeField] protected float _speed = 7f;
        protected Vector3 _dir = Vector3.forward;
        protected float _damage = 1f;

        protected Rigidbody _rb;

        public Vector3 Dir => _dir;
        public float Speed => _speed;
        public float Damage => _damage;
        
        public void Awake() {
            _rb = GetComponent<Rigidbody>();
        }

        public virtual void Initialize(Vector3 dir, float damage) {
            _dir = dir;
            _damage = damage;
            
            _rb ??= GetComponent<Rigidbody>();
            _rb.velocity = _dir * _speed;

            transform.rotation = Quaternion.LookRotation(_dir);
            
            Destroy(gameObject, k_expirationDelay);
        }

        public virtual void OnCollisionEnter(Collision other) {
            other.rigidbody?.GetComponent<IDamageable>()?.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}