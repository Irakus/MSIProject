using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    string ActionDescription { get; }
    bool Available { get; }
    void Interact();
}
