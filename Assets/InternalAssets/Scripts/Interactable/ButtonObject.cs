using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonObject : MonoBehaviour,IInteractable
{
    private string useDescription = "активации";

    public UnityEvent onPush;
        
    public void Interact()
    {
        onPush?.Invoke();
    }

    public string GetDescription()
    {
        return $"Нажмите <color=blue>[E]</color> для " + useDescription;
    }
}
