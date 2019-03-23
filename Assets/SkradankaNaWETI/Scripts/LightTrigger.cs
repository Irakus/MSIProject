using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] private VisibilityCounter _visibilityCounter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="FPSController")
            _visibilityCounter.Increment();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
            _visibilityCounter.Decrement();
    }
}
