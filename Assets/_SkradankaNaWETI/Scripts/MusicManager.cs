using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource passiveMusic;
    [SerializeField]
    private AudioSource aggresiveMusic;


    private static int chasingEnemies = 0;
    private static readonly float volume = 0.1f;
    private static readonly float fadeTime = 5.0f;

    void Awake()
    {
        passiveMusic.volume = volume;
        aggresiveMusic.volume = 0.0f;
    }

    public void IncrementChasing()
    {
        if (chasingEnemies == 0)
        {
            StartCoroutine(FadeOut(passiveMusic));
            StartCoroutine(FadeIn(aggresiveMusic));
        }
        chasingEnemies++;
    }
    public void DecrementChasing()
    {
        chasingEnemies--;
        if (chasingEnemies == 0)
        {
            StartCoroutine(FadeOut(aggresiveMusic));
            StartCoroutine(FadeIn(passiveMusic));
        }
       
    }

    private static IEnumerator FadeOut(AudioSource audioSource)
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= volume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Pause();
    }

    private static IEnumerator FadeIn(AudioSource audioSource)
    {
        audioSource.Play();

        while (audioSource.volume < volume)
        {
            audioSource.volume += volume * Time.deltaTime / fadeTime;

            yield return null;
        }
    }
}
