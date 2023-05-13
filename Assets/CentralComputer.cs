using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralComputer : MonoBehaviour,IInteractable
{
    [SerializeField] private UnityEvent onSystemRefresh;
    
    public void Interact()
    {
        onSystemRefresh.Invoke();
    }

    public string GetDescription()
    {
        return $"Нажмите <color=blue>[E]</color> для перезагрузки системы";
    }
}
