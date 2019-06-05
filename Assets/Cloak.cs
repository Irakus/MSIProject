using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloak : MonoBehaviour, IInteractable
{
    public string ActionDescription => "Zabierz kurtkę";

    public bool Available => true;

    public void Interact()
    {
        FindObjectOfType<MissionManager>().GoalFulfilled();
        gameObject.active = false;
    }
}
