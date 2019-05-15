using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTrigger : MonoBehaviour
{
    [SerializeField] AudioSource ambience;
    AudioLowPassFilter lpf;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    public void Awake()
    {
        lpf = ambience.GetComponent<AudioLowPassFilter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.FindObjectOfType<GameManager>().Escaped();
        StopCoroutine("ActivateLpf");
        StartCoroutine("RemoveLpf");
    }

    private void OnTriggerExit(Collider other)
    {
        
        StopCoroutine("RemoveLpf");
        StartCoroutine("ActivateLpf");
    }

    private IEnumerator ActivateLpf()
    {
        while (lpf.cutoffFrequency > 1555)
        {
            lpf.cutoffFrequency = Mathf.SmoothDamp(lpf.cutoffFrequency, 1555, ref yVelocity, smoothTime);
            yield return null;
        }
    }

    private IEnumerator RemoveLpf()
    {
        while (lpf.cutoffFrequency < 20000)
        {
            lpf.cutoffFrequency = Mathf.SmoothDamp(lpf.cutoffFrequency, 20000, ref yVelocity, smoothTime);
            yield return null;
        }
    }

}
