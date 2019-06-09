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

    string missionTime;

    static string[] endScreenDescription = {
        "Gracz został złapany! \n Kliknij spacje aby wrócić do menu głównego.",
        "\n Kliknij spacje aby wrócić do menu głównego."
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
            if((float)Score.Get() > PlayerPrefs.GetFloat("Player Score"))
            {
                PlayerPrefs.SetFloat("Player Score", (float)Score.Get());
            }

        }
        text.text = endScreenDescription[EndScreenType.Get()];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
