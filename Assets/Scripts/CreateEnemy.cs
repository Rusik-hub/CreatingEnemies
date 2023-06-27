using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private Rigidbody _enemy;
    [SerializeField] private float _respawnTime;
    [SerializeField] private float _runningTime;
    
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _points[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        if (_runningTime >= _respawnTime)
        {
            int numberOfRespawn = Random.Range(0, _points.Length);

            Instantiate(_enemy, _points[numberOfRespawn].transform);
            _runningTime = 0;
        }
    }
}
