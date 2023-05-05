using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu (menuName = "DialogSystem/Dialog")]
public class Dialog : ScriptableObject
{
    [ReorderableList]
    public List<Message> Messages;

    public void AddToQueue()
    {
        Speaker.Instance.AddMessages(this);
    }
}
