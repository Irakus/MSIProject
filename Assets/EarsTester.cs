using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarsTester : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject.FindObjectOfType<Ears>().Hear(transform);
        }
    }
}
