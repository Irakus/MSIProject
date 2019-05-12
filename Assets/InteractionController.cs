using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Text _text;
    [SerializeField] private Image _panel;
    private IInteractable _interactionTarget;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        StartCoroutine(ScanForInteractables());
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && _interactionTarget != null){
            _interactionTarget.Interact();
        }
    }

    private IEnumerator ScanForInteractables()
    {
        while (true)
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(_camera.transform.position, _camera.transform.TransformDirection(Vector3.forward), out hit, 2.0f);
            // Does the ray intersect any objects excluding the player layer
            if (hasHit)
            {
                _interactionTarget = hit.collider.GetComponent<IInteractable>();
                if (_interactionTarget != null)
                {
                    _panel.gameObject.SetActive(true);
                    _text.text = _interactionTarget.ActionDescription;
                }
                else
                    _panel.gameObject.SetActive(false);
            }
            else
                _panel.gameObject.SetActive(false);
            yield return new WaitForSeconds(.15f);
        }
    }


}
