using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    private Ears[] ears;

    private void Awake()
    {
        ears = null;
    }

    public void MakeNoise(float radius)
    {
        if(ears==null)
            ears = EarsProvider.Get();
        foreach(var e in ears)
        {
            bool isTotalDistanceOk = Vector3.Distance(transform.position, e.transform.position) < radius;
            bool isVerticalDistanceOk = Mathf.Abs(transform.position.y - e.transform.position.y) < 1.5;
            if (isTotalDistanceOk && isVerticalDistanceOk)
            {
                e.Hear(transform);
            }
        }
    }
}
