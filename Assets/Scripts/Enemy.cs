using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private Transform _currentTarget;
    [SerializeField]private List<Transform> _targets;
    [SerializeField]private int _targetIndex = 0;

    private float _speed = 1f;

    public void Init(List<Transform> targets)
    {
        _targets = targets;

        _currentTarget = _targets[_targetIndex];
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Target>())
        {
            _targetIndex++;

            if (_targetIndex >= _targets.Count)
                Destroy(this.gameObject);
            else                
                _currentTarget = _targets[_targetIndex];
        }
    }
}
