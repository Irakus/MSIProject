using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform player;
    private bool pendriveTaken = false;
    private bool playerWasted = false;

    public RectTransform description;

    public void PlayerWasted()
    {
        playerWasted = true;
        Debug.Log("Gracz został złapany!");
        SceneManager.LoadScene(0);
    }

    public void PendriveTaken()
    {
        pendriveTaken = true;
    }

    public void Escaped()
    {
        if(!playerWasted)
        {
            if(pendriveTaken)
            {
                Debug.Log("Misja wygrana!");
            }
            else
            {
                Debug.Log("Cofnij się po pendriva!");
            }
        }
    }
    
}
