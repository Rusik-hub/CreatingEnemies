using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private Transform _enemyContainer;

    [SerializeField, Range(0.1f, 10f)] private float _spawnSpeed;

    private bool _isWork;

    private void Start()
    {
        _isWork = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent<Path>(out Path path))
                _targets = path.GetPath();

            if (transform.GetChild(i).TryGetComponent<EnemyContainer>(out EnemyContainer container))
                _enemyContainer = container.transform;
        }

        var addEnemyJob = StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        var delay = new WaitForSeconds(_spawnSpeed);

        while (_isWork)
        {
            int startPointIndex = 0;

            yield return delay;

            Enemy enemy = Instantiate(_enemyPrefab, _targets[startPointIndex].transform.position, Quaternion.identity, _enemyContainer);

            enemy.Init(_targets);
        }
    }
}