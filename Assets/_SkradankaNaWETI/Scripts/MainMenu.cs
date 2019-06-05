using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button mission1Button;
    [SerializeField] private Button mission2Button;
    [SerializeField] private Button mission3Button;

    public void Start()
    {
        int unlockedMissions = PlayerPrefs.GetInt("missionsCleared")+1;
        if(unlockedMissions<3)
        {
            if (unlockedMissions < 2)
                mission2Button.interactable = false;
            mission3Button.interactable = false;
        }
    }

    public void Mission1()
    {
        MissionNumber.Set(1);
        SceneManager.LoadScene(1);
    }

    public void Mission2()
    {
        MissionNumber.Set(2);
        SceneManager.LoadScene(1);
    }

    public void Mission3()
    {
        MissionNumber.Set(3);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
