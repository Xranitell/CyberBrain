using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu (menuName = "DialogSystem/Message")]

[Serializable]
public class Message
{
    public Actor actor;
    public AudioClip messageRecord;
    [ResizableTextArea] public string messageText;
    public float additiveWaitTime = 1f;
    public UnityEvent onPlayMessage;
}

public enum Actor
{
    Билли,
    Нэнси
}
