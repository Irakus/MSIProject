using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        image.CrossFadeAlpha(0, 3f, true);
    }
}
