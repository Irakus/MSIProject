using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    string ActionDescription { get; }
    void Interact();
}
