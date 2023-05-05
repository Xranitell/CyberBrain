using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private Animator messagePanel;
    private bool _panelIsActive;
    
    [SerializeField] private TextAnimation messageAnimator;
    [SerializeField] private TMP_Text messageActor;

    public AudioSource source;
    
    public Queue<Message> DialogQueue = new Queue<Message>();

    public static Speaker Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {

        if (messageAnimator.animationEnded
            && DialogQueue.Count > 0)
        {
            if(!_panelIsActive) messagePanel.SetTrigger("Activate");

            _panelIsActive = true;
            PlayMessage(DialogQueue.Dequeue());
        }
        else if (DialogQueue.Count <= 0 && _panelIsActive == true && messageAnimator.animationEnded)
        {
            _panelIsActive = false;
            messagePanel.SetTrigger("Deactivate");
        }
    }
    
    private void PlayMessage(Message message)
    {
        source.PlayOneShot(message.messageRecord);
        messageActor.text = message.actor.ToString();

        StartCoroutine(messageAnimator
            .AnimateText(message.messageText, message.messageRecord.length, message.additiveWaitTime));
        
        source.Play();
        message.onPlayMessage.Invoke();
    }

    public void AddMessages(Dialog dialog)
    {
        foreach (var msg in dialog.Messages)
        {
            DialogQueue.Enqueue(msg);
        }
    }
}
