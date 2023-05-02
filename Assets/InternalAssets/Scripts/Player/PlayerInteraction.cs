using System;
using System.Collections;
using System.Collections.Generic;
using Terminal;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionDistance = 5f;
    public GameObject interactionUI;
    public TMP_Text interactionText;

    private GameObject _cachedHitObject;
    private IInteractable _interactable;

    void Update()
    {
        InteractionRay();
        CallRobot();
    }


    public void CallRobot()
    {
        if (Input.GetKey(KeyCode.R))
        {
            RobotController.Instance.TeleportToPlayer();
        }
    }
    private void InteractionRay()
    {
        Ray ray = PlayerMainScript.Instance.playerCamera.ViewportPointToRay(Vector3.one / 2f);

        RaycastHit hit;
        bool hitSomething = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if ( _cachedHitObject != hit.collider.gameObject || _cachedHitObject == null)
            {
                _interactable = hit.collider.GetComponent<IInteractable>();
            }
            
            if (_interactable != null)
            {
                hitSomething = true;
                interactionText.text = _interactable.GetDescription();

                if (Input.GetKey(KeyCode.E))
                {
                    _interactable.Interact();
                }
            }

            _cachedHitObject = hit.collider.gameObject;
        }

        if (interactionUI.activeSelf != hitSomething && enabled)
        {
            interactionUI.SetActive(hitSomething);
            Debug.Log("Activate");
        };

    }
}
