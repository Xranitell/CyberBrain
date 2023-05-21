using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanciInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        
    }

    public string GetDescription()
    {
        return $"Нажмите <color=blue>[E]</color> что-бы погладить Нэнси";
    }
}
