using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _applePrefab;
    [SerializeField] private Collider _spawnCollider;

    private void Start()
    {
        SpawnApple();
    }

    public void SpawnApple()
    {
        Bounds bounds = _spawnCollider.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        Instantiate(_applePrefab, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
    }
}
