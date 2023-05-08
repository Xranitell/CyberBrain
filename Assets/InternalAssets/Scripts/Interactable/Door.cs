using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    private bool isOpened = false;

    private void Start()
    {
        
    }

    public void Interact()
    {
        isOpened = !isOpened;

        animator.SetTrigger(isOpened ? "Open":"Close");
    }

    public string GetDescription()
    {
        string state = isOpened ? "<color=red>Закрытия</color>" : "<color=green>Открытия</color>";
        return $"Нажмите <color=blue>[E]</color> для {state} двери";
    }
}
