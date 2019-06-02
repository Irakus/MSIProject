using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class VoicePack : MonoBehaviour
{
    [SerializeField]
    private List<AudioSource> casualTracks;
    [SerializeField]
    private List<AudioSource> chasingTracks;
    [SerializeField]
    private List<AudioSource> spottedTracks;
    [SerializeField]
    private List<AudioSource> lostTracks;
    
    [SerializeField]
    private AudioSource currentlyPlaying;

    private static Random rnd = new Random();

    public void PlaySpotted()
    {
        if (currentlyPlaying) currentlyPlaying.Stop();
        currentlyPlaying = spottedTracks[Random.Range(0, spottedTracks.Count)];
        currentlyPlaying.Play();
    }


    public void PlayCasual()
    {
        currentlyPlaying = casualTracks[Random.Range(0, casualTracks.Count)];
        currentlyPlaying.Play();
    }

    public void PlayChasing()
    {
        currentlyPlaying = chasingTracks[Random.Range(0, chasingTracks.Count)];
        currentlyPlaying.Play();
    }

    public void PlayLost()
    {
        if (currentlyPlaying) currentlyPlaying.Stop();
        currentlyPlaying = lostTracks[Random.Range(0, lostTracks.Count)];
        currentlyPlaying.Play();
    }

    public bool IsPlaying()
    {
        return currentlyPlaying.isPlaying;
    }

    void Awake()
    {
        currentlyPlaying = null;
    }
    void Update()
    {
        if (currentlyPlaying && !currentlyPlaying.isPlaying) currentlyPlaying = null;
    }
}
