using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarsProvider : MonoBehaviour
{
    static Ears[] ears;
    // Start is called before the first frame update
    void Awake()
    {
        ears = FindObjectsOfType<Ears>();
    }

    public static Ears[] Get()
    {
        return ears;
    }
}
