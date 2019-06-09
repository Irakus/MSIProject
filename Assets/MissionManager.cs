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
    [SerializeField] Cloak cloak;
    [SerializeField] GameObject pendriveComputer;
    [SerializeField] ETIFirstPersonController player;

    void Awake()
    {
        missionNumber = MissionNumber.Get();
        switch (missionNumber)
        {
            case 1:
                pendriveComputer.SetActive(true);
            break;
            case 2:
                goalFulfilled = true;
            break;
            case 3:
                cloak.gameObject.SetActive(true);
            break;
        }

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
            EndScreenType.Set(1);
            SceneManager.LoadScene(2);
        }
    }

    internal void GoalFulfilled()
    {
        goalFulfilled = true;
    }
}
