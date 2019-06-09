using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static string[] missionGoals = {
        "",
        "Odzyskaj zaginionego pendrajwa z laboratorium na 1. piętrze!",
        "Ucieknij z ETI!",
        "Zabierz z szatni swoją kurtkę!"
    };
    public Transform player;
    private bool playerWasted = false;

    public RectTransform description;
    Text text;

    public RectTransform time;
    Text timeText;

    private static float actionTime = 3.0f;
    private double startTime = 0.0f;

    public void PlayerWasted()
    {
        playerWasted = true;
        text.text = "Gracz został złapany!";
        EndScreenType.Set(0);
        SceneManager.LoadScene(2);
    }

    void Start()
    {
        text = description.GetComponent<Text>();
        text.text = missionGoals[MissionNumber.Get()];
        startTime = Time.time;
    }

    void Update()
    {
        timeText = time.GetComponent<Text>();
        System.TimeSpan t = System.TimeSpan.FromSeconds(Time.time - startTime);
        Score.Set(Time.time - startTime);
        timeText.text = string.Format("Czas misji: {1:D2}m {2:D2}s",
                                t.Hours,
                                t.Minutes,
                                t.Seconds,
                                t.Milliseconds);

        if (Time.time - startTime > actionTime)
        {
            text.text = "";
        }
    }

}
