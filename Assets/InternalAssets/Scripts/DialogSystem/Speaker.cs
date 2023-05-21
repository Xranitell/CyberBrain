using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Laboratory;
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
        var messageAnimationDuration = 3f;
        
        if (message.messageRecord != null)
        {
             messageAnimationDuration = message.messageRecord.length;
             source.PlayOneShot(message.messageRecord);
        }
        
        messageActor.text = message.actor.ToString();

        StartCoroutine(messageAnimator
            .AnimateText(message.messageText, messageAnimationDuration, message.additiveWaitTime));
        
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
