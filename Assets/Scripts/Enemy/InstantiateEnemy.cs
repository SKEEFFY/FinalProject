using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField] private EnemyStats _prefabEnemy;
    [SerializeField] private Transform[] _spawnPositions;

    private void Start()
    {
        for(int i = 0; i < _spawnPositions.Length; i++)
        {
            var newEnemy = Instantiate(_prefabEnemy, _spawnPositions[i].transform.position, Quaternion.identity);
        }
    }
}
