using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CentralComputer : MonoBehaviour,IInteractable
{
    [SerializeField] private UnityEvent onSystemRefresh;

    private bool isCrushed;

    public void Interact()
    {
        if (isCrushed)
        {
            isCrushed = false;
            onSystemRefresh.Invoke();
        }
        
    }

    public string GetDescription()
    {
        return $"Нажмите <color=blue>[E]</color> для перезагрузки системы";
    }
}
