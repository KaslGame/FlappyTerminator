using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject[] _templates;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;

    private int _lastSpawnPointNumber = -1;
    private float _elapsedTime;

    private void Start()
    {
        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                SetObject(enemy, _spawnPoints[GetRandomPointNumber()].position);
                DisableObjectAboardScreen();
            }
        }
    }

    private int GetRandomPointNumber()
    {
        int spawnPointNumber = 0;

        if (_lastSpawnPointNumber == -1)
        {
            spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        }
        else
        {
            if (spawnPointNumber != _lastSpawnPointNumber)
                spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            while (spawnPointNumber == _lastSpawnPointNumber)
                spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        }

        _lastSpawnPointNumber = spawnPointNumber;

        return spawnPointNumber;
    }

    private void SetObject(GameObject enemy, Vector3 spawPoint)
    {
        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawPoint;
        enemy.GetComponent<Enemy>().SetTarget(_target);
    }
}
