using System;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Rubika {
    public class PlayerController : MonoBehaviour {
        [Header("Attributes")]
        [SerializeField] float _speed = 5f;

        [SerializeField] float _rotationSpeed = 12f;
        Vector3 _lastVelocity;
        
        [Header("References")]
        [SerializeField] InputReader _input;

        [SerializeField] Camera _camera;

        Rigidbody _rb;
        
        void Awake() {
            _rb = GetComponent<Rigidbody>();
            _lastVelocity = Vector3.zero;
        }

        void Start() {
            _input.Enable();
        }

        void FixedUpdate() {
            Vector2 moveVector = _input.Move;
            if (moveVector != Vector2.zero) {
                HandleMovement(moveVector);
                LimitSpeed();
                _lastVelocity = _rb.velocity;
            }
            
            HandleRotation();
        }

        void HandleMovement(Vector2 moveVector) {
            Vector3 dir = _camera.transform.right * moveVector.x + _camera.transform.forward * moveVector.y;
            _rb.AddForce(dir * _speed, ForceMode.Force);
        }

        void HandleRotation() {
            if (_lastVelocity == Vector3.zero) return;
            var rot = Quaternion.LookRotation(_lastVelocity.With(y: 0f).normalized, Vector3.up);
            var smoothRot = Quaternion.Slerp(_rb.rotation, rot, Time.fixedDeltaTime * _rotationSpeed);
            _rb.MoveRotation(smoothRot);
        }
        
        void LimitSpeed() {
            Vector3 flatVel = _rb.velocity.With(y: 0f);
            if (flatVel.magnitude <= _speed) return;
            _rb.velocity = flatVel.normalized * _speed + Vector3.up * _rb.velocity.y;
        }
    }
}
