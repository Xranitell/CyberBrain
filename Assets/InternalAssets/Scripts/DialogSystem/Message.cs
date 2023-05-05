using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//[CreateAssetMenu (menuName = "DialogSystem/Message")]

[Serializable]
public class Message
{
    public Actor actor;
    public AudioClip messageRecord;
    public string messageText;
    public float additiveWaitTime = 1f;

    public UnityEvent onPlayMessage;
}

public enum Actor
{
    Игрок,
    Робот
}
