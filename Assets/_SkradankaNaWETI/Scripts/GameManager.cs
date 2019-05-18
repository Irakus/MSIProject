using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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

    public void PendriveTaken()
    {
        pendriveTaken = true;
    }

    public void Escaped()
    {
        if (!playerWasted)
        {
            if (pendriveTaken)
            {
                text.text = "Misja wygrana!";
                startTime = Time.time;
                Debug.Log("Misja wygrana!");
            }
            else
            {
                text.text = "Cofnij się po pendriva!";
                startTime = Time.time;
                Debug.Log("Cofnij się po pendriva!");
            }
        }
    }

    void Start()
    {
        text = description.GetComponent<Text>();
        text.text = "Start";
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
