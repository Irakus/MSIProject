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
    private bool pendriveTaken = false;
    private bool playerWasted = false;

    public RectTransform description;
    Text text;

    private static float actionTime = 3.0f;
    private float startTime = 0.0f;

    public void PlayerWasted()
    {
        playerWasted = true;
        text.text = "Gracz został złapany!";
        startTime = Time.time;
        Debug.Log("Gracz został złapany!");
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        text = description.GetComponent<Text>();
        text.text = missionGoals[MissionNumber.Get()];
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime > actionTime)
        {
            text.text = "";
        }
    }

}
