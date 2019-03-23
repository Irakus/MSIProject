using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityCounter : MonoBehaviour
{
    int visibility;
    Text text;

    internal void Increment()
    {
        text.text = (++visibility).ToString();
    }

    internal void Decrement()
    {
        text.text = (--visibility).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        visibility = 0;
        text = GetComponent<Text>();
    }
}
