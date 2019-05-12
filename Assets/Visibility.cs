using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    [SerializeField] private VisibilityCounter _visibilityCounter;
    private int _visibilityCount;

    private void Awake()
    {
        _visibilityCount = 0;
    }

    public int Get()
    {
        return _visibilityCount;
    }

    public void Increment()
    {
        _visibilityCounter.Show(++_visibilityCount);
    }

    public void Decrement()
    {
        _visibilityCounter.Show(--_visibilityCount);
    }
}
