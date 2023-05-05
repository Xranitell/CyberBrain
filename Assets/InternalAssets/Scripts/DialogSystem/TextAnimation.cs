using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(TMP_Text))]public class TextAnimation : MonoBehaviour
{
    private TMP_Text tmpText;

    public bool animationEnded = true;

    private void Awake()
    {
        tmpText = GetComponent<TMP_Text>();
    }
    
    public IEnumerator AnimateText(string messageText, float animationDuration, float additiveWaitTime)
    {
        tmpText.text = string.Empty;
        
        animationEnded = false;
        var delay = animationDuration / messageText.Length;
        
        foreach (var messageChar in messageText)
        {
            tmpText.text += messageChar;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(additiveWaitTime);
        animationEnded = true;
    }
}

