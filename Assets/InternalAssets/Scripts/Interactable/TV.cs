using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TV : MonoBehaviour, IInteractable
{
    [SerializeField] private VideoPlayer player;
    public bool isOn = false;
    public void Interact()
    {
        isOn = !isOn;

        if (isOn)
        {
            player.gameObject.SetActive(true);
            player.Play();
        }
        else
            player.gameObject.SetActive(false);
    }
    public string GetDescription()
    {
        string state = isOn ? "<color=red>Выключения</color>" : "<color=green>Включения</color>";
        return $"Нажмите <color=blue>[E]</color> для {state} дисплея";
    }
}
