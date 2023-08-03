using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;

    public List<Transform> GetPath()
    {
        return _targets;
    }

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _targets.Add(transform.GetChild(i));
        }
    }
}
