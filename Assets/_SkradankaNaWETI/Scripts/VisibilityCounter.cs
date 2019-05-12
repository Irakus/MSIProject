using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisibilityCounter : MonoBehaviour
{
    int visibility;
    Image image;

    private static Color darkColour = new Color(0.2f, 0.2f, 0.2f);
    private static Color mediumColour = new Color(0.6f, 0.6f, 0.6f);
    private static Color lightColour = Color.white;

    float smoothTime = 1f;
    float yVelocity = 0.0f;

    internal void Show(int value)
    {
        switch (value)
        {
            case 0:
                StopAllCoroutines();
                StartCoroutine("FadeToDark");
                break;
            case 1:
                StopAllCoroutines();
                StartCoroutine("FadeToMedium");
                break;
            default:
                StopAllCoroutines();
                StartCoroutine("FadeToLight");
                break;
        }
    }

    IEnumerator FadeToDark()
    {
        var startTime = Time.time;
        while (Mathf.Abs(image.color.grayscale - darkColour.grayscale) > 0.01f)
        {
            image.color = Color.Lerp(image.color, darkColour, (Time.time-startTime)/smoothTime);
            yield return null;
        }
    }

    IEnumerator FadeToMedium()
    {
        var startTime = Time.time;
        while (Mathf.Abs(image.color.grayscale - mediumColour.grayscale) > 0.01f)
        {
            image.color = Color.Lerp(image.color, mediumColour, (Time.time - startTime) / smoothTime);
            yield return null;
        }
    }

    IEnumerator FadeToLight()
    {
        var startTime = Time.time;
        while (Mathf.Abs(image.color.grayscale - lightColour.grayscale) >0.01f)
        {
            image.color = Color.Lerp(image.color, lightColour, (Time.time - startTime) / smoothTime);
            yield return null;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }
}
