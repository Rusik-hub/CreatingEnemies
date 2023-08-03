using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemyPrefabs;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private Transform[] _parentsForEnemies;

    [SerializeField, Range(0.1f, 10f)] private float _spawnSpeed;

    private bool _isWork;

    private void Start()
    {
        _isWork = true;

        var addEnemyJob = StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        var delay = new WaitForSeconds(_spawnSpeed);

        while (_isWork)
        {
            int enemyIndex = Random.Range(0, _targets.Length);

            yield return delay;

            Enemy enemy = Instantiate(_enemyPrefabs[enemyIndex], _targets[enemyIndex].transform.position, Quaternion.identity, _parentsForEnemies[enemyIndex]);

            enemy.Init(_targets[enemyIndex].GetComponent<Path>().GetPath());
        }
    }
}