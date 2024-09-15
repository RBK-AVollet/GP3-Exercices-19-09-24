using System;
using Padrox.Acelab.Timers;
using UnityEngine;

namespace Rubika {
    public class GunManager : MonoBehaviour {
        [Header("Weapons")]
        [SerializeField] Gun[] _weapons;
        int _currentWeapon;
        
        [Header("References")]
        [SerializeField] InputReader _input;

        [SerializeField] Transform _firePoint;
        [SerializeField] RectTransform _crosshair;
        [SerializeField] Camera _camera;

        CountdownTimer _weaponCooldownTimer;

        void Awake() {
            _currentWeapon = 0;
        }

        void Start() {
            for (int i = 0; i < _weapons.Length; i++) {
                _weapons[i].SetManager(this);
            }
            EquipWeapon();
        }

        void OnEnable() {
            _input.OnCycleWeaponEvent += CycleWeapon;
        }

        void OnDisable() {
            _input.OnCycleWeaponEvent -= CycleWeapon;
        }

        void Update() {
            if (!_input.Fire) return;
            if (!_weaponCooldownTimer.IsFinished) return;
            
            _weapons[_currentWeapon].Shoot();
            _weaponCooldownTimer.Start();
        }

        void CycleWeapon() {
            _currentWeapon = ++_currentWeapon % _weapons.Length;
            EquipWeapon();
        }

        void EquipWeapon() {
            for (int i = 0; i < _weapons.Length; i++) {
                _weapons[i].gameObject.SetActive(i == _currentWeapon);
            }
            
            float cooldown = 1f / _weapons[_currentWeapon].GunData.fireRate;
            if(_weaponCooldownTimer == null)
                _weaponCooldownTimer = new CountdownTimer(cooldown);
            else
                _weaponCooldownTimer.Reset(cooldown);
        }
        
        Vector3 GetShootTargetPoint() {
            Vector3 crosshairScreenPos = _crosshair.position;
            Vector3 crosshairWorldPos = _camera.ScreenToWorldPoint(crosshairScreenPos.With(z: _camera.nearClipPlane));

            const float maxDistance = 1000f;
            bool contact = Physics.Raycast(crosshairWorldPos, _camera.transform.forward, out RaycastHit hit, maxDistance);
            
            Vector3 targetPoint = contact ? hit.point : crosshairWorldPos + _camera.transform.forward * maxDistance;
            
            return targetPoint;
        }

        public Vector3 GetShootDirFromFirePoint(Transform firePoint) {
            Vector3 dir = (GetShootTargetPoint() - firePoint.position).normalized;
            return dir;
        }
    }
}
