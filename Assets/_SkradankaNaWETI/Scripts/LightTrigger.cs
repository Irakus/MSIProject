using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private VisibilityCounter _visibilityCounter;

    private void OnTriggerEnter(Collider other)
    {
        Visibility v = other.GetComponent<Visibility>();
        if(v != null)
            v.Increment();
    }

    private void OnTriggerExit(Collider other)
    {
        Visibility v = other.GetComponent<Visibility>();
        if (v != null)
            v.Decrement();
    }
}
