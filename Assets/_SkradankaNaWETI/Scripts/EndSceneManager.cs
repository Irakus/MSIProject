using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{

    public RectTransform description;
    Text text;

    public RectTransform score;
    Text scoreText;

    public InputField nameInput;
    public GameObject nameInputGameObject;

    string missionTime;

    static string[] endScreenDescription = {
        "Gracz został złapany! \n Kliknij enter aby wrócić do menu głównego.",
        "\n Kliknij enter aby wrócić do menu głównego."
    };

    // Start is called before the first frame update
    void Start()
    {
        
        text = description.GetComponent<Text>();
        if(EndScreenType.Get() == 1)
        {
            scoreText = score.GetComponent<Text>();
            System.TimeSpan t = System.TimeSpan.FromSeconds(Score.Get());
            scoreText.text = string.Format("Misja " + MissionNumber.Get() + " ukończona w czasie: {1:D2}m {2:D2}s!",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
            this.nameInputGameObject.SetActive(true);
            this.nameInput.ActivateInputField();
            this.nameInput.Select();
        }
        text.text = endScreenDescription[EndScreenType.Get()];
        
    }

    void saveScore()
    {
        bool scoreSet = false;
        for (int i = 1; i <= 3 && !scoreSet; i++)
        {
            if ((float)Score.Get() < PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + i) || PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + i) == 0)
            {
                if (i == 1)
                {
                        Debug.Log("Mission" + MissionNumber.Get() + " Score" + 3 + ": " + PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 2));
                        PlayerPrefs.SetString("Mission" + MissionNumber.Get() + "Score" + 3 + "Player", PlayerPrefs.GetString("Mission" + MissionNumber.Get() + "Score" + 2 + "Player"));
                        PlayerPrefs.SetFloat("Mission" + MissionNumber.Get() + "Score" + 3, PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 2));

                        Debug.Log("Mission" + MissionNumber.Get() + " Score" + 2 + ": " + PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 1));
                        PlayerPrefs.SetString("Mission" + MissionNumber.Get() + "Score" + 2 + "Player", PlayerPrefs.GetString("Mission" + MissionNumber.Get() + "Score" + 1 + "Player"));
                        PlayerPrefs.SetFloat("Mission" + MissionNumber.Get() + "Score" + 2, PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 1));
                    

                }
                else if (i == 2)
                {
                    
                        Debug.Log("Mission" + MissionNumber.Get() + " Score" + 3 + ": " + PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 2));
                        PlayerPrefs.SetString("Mission" + MissionNumber.Get() + "Score" + 3 + "Player", PlayerPrefs.GetString("Mission" + MissionNumber.Get() + "Score" + 2 + "Player"));
                        PlayerPrefs.SetFloat("Mission" + MissionNumber.Get() + "Score" + 3, PlayerPrefs.GetFloat("Mission" + MissionNumber.Get() + "Score" + 2));
                    

                }
                PlayerPrefs.SetString("Mission" + MissionNumber.Get() + "Score" + i + "Player", this.nameInput.text);
                PlayerPrefs.SetFloat("Mission" + MissionNumber.Get() + "Score" + i, (float)Score.Get());
                Debug.Log("Mission" + MissionNumber.Get() + " Score" + i + ": " + (float)Score.Get());
                scoreSet = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            saveScore();
            Debug.Log(this.nameInput.text);
            SceneManager.LoadScene(0);
        }
    }
}
