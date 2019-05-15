using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestPendrive : MonoBehaviour, IInteractable
{
    private ParticleSystem _particleSystem;
    private bool _pendriveTaken;

    public bool Available
    {
        get
        {
            return !_pendriveTaken;
        }
    }

    public string ActionDescription
    {
        get
        {
            return "Zaginiony pendrive";
        }
    }

    public void Interact()
    {
        var emission = _particleSystem.emission;
        emission.enabled = false;
        _pendriveTaken = true;
        Debug.Log("Zdobyłeś Pendrive!");
    }

    // Start is called before the first frame update
    void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _pendriveTaken = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
