using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour, IInteractable
{
    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
    [SerializeField] private AudioSource source;

    private bool isOn = false;

    public void Interact()
    {
        isOn = !isOn;
        source.mute = !isOn;
    }

    public string GetDescription()
    {
        string state = isOn ? "<color=red>выключения</color>" : "<color=green>включения</color>";
        return $"Нажмите <color=blue>[E]</color> для {state} радио";
    }
}
