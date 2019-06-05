using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    bool goalFulfilled = false, escaped = false;
    int missionNumber;
    [SerializeField] Transform[] startSpots;
    [SerializeField] ETIFirstPersonController player;

    void Awake()
    {
        missionNumber = MissionNumber.Get();
        if (missionNumber == 2)
            goalFulfilled = true;

        player.transform.position = startSpots[missionNumber].position;
        player.transform.rotation = startSpots[missionNumber].rotation;
        player.GetComponent<CharacterController>().enabled = true;

    }

    internal void Escaped()
    {
        if (goalFulfilled)
        {
            if (PlayerPrefs.GetInt("missionsCleared") < missionNumber)
                PlayerPrefs.SetInt("missionsCleared", missionNumber);
        SceneManager.LoadScene(0);
        }
    }

    internal void GoalFulfilled()
    {
        goalFulfilled = true;
    }
}
