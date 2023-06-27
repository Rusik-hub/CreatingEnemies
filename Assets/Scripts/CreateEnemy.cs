using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Transform[] _points;
    private bool _isWork;

    private void Start()
    {
        _points = new Transform[transform.childCount];
        _isWork = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }

        var addEnemyJob = StartCoroutine(AddEnemy());
    }

    private IEnumerator AddEnemy()
    {
        var waitTwoSeconds = new WaitForSeconds(2f);

        while (_isWork)
        {
            int numberOfRespawn = Random.Range(0, _points.Length);

            yield return waitTwoSeconds;

            Instantiate(_enemy, _points[numberOfRespawn].transform);
        }
    }
}