using UnityEngine;

namespace Rubika {
    public class Bullet : MonoBehaviour {
        const float k_expirationDelay = 20f;

        [Header("Attributes")]
        [SerializeField] float _speed = 7f;
        Vector3 _dir = Vector3.forward;

        Rigidbody _rb;

        public Vector3 Dir => _dir;
        public float Speed => _speed;
        
        public void Awake() {
            _rb = GetComponent<Rigidbody>();
        }

        public virtual void Initialize(Vector3 dir) {
            _dir = dir;
            
            _rb ??= GetComponent<Rigidbody>();
            _rb.velocity = _dir * _speed;

            transform.rotation = Quaternion.LookRotation(_dir);
            
            Destroy(gameObject, k_expirationDelay);
        }

        public void OnCollisionEnter(Collision other) {
            Destroy(gameObject);
        }
    }
}