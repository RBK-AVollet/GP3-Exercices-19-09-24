using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Rubika
{
    public class TargetSpawner : MonoBehaviour {
        [Header("Settings")]
        [SerializeField] int _targetCount = 10;
        [SerializeField] float _spawnVariation = 0.3f;
        [SerializeField] float _spawnRadius = 30f;
        [SerializeField] float _maxRadiusRatio = 1.5f;
        
        [Header("References")]
        [SerializeField] GameObject _targetPrefab;

        Transform _targetsParent;
        
        void Start() {
            _targetsParent = new GameObject("Targets").transform;
            
            int minCount = Mathf.FloorToInt(_targetCount * (1-_spawnVariation));
            int maxCount = Mathf.FloorToInt(_targetCount * (1+_spawnVariation));
            int targetCount = Random.Range(minCount, maxCount);
            for (int i = 0; i < targetCount; i++) {
                SpawnTarget();
            }
        }

        void SpawnTarget() {
            Vector3 pos = transform.position.RandomPointInAnnulus(_spawnRadius, _spawnRadius * _maxRadiusRatio).With(y: 0f);
            Quaternion rot = Quaternion.Euler(0f, Random.Range(-360, 361), 0f);
            var target = Instantiate(_targetPrefab, pos, rot, _targetsParent);
        }

        void OnDrawGizmosSelected() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);
            
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius * _maxRadiusRatio);
        }
    }
}
