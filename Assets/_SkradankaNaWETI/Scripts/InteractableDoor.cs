﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable
{
    enum DoorStatus
    {
        Open, Closed, Inbetween
    }

    private DoorStatus _status;
    private Quaternion _closedRotation;
    private Quaternion _openRotation;
    private static float actionTime = 0.5f;
    [SerializeField] private AudioSource _closeAudio;
    [SerializeField] private AudioSource _openAudio;


    private void Awake()
    {
        _status = DoorStatus.Closed;
        _closedRotation = transform.rotation;
        _openRotation = transform.rotation * Quaternion.Euler(0, 90, 0);
    }

    public string ActionDescription { get
        {
            return "Drzwi";
        }
    }

    public void Interact()
    {
        if (_status == DoorStatus.Closed)
            StartCoroutine(Open());
        else if (_status == DoorStatus.Open)
            StartCoroutine(Close());
    }

    private IEnumerator Close()
    {
        _status = DoorStatus.Inbetween;
        _closeAudio.Play();
        var startTime = Time.time;
        while (Time.time - startTime < actionTime)
        {
            transform.rotation = Quaternion.Slerp(_openRotation, _closedRotation, (Time.time - startTime) * 2);
            yield return null;
        };
        _status = DoorStatus.Closed;
    }

    private IEnumerator Open()
    {
        _status = DoorStatus.Inbetween;
        _openAudio.Play();
        var startTime = Time.time;
        while (Time.time-startTime<actionTime)
        {
            transform.rotation = Quaternion.Slerp(_closedRotation, _openRotation, (Time.time - startTime)*2);
            yield return null;
        };
        _status = DoorStatus.Open;
    }
}