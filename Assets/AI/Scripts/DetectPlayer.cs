using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Change the cube color to green.
        if (other.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<GameManager>().PlayerWasted();
        };
    }
}