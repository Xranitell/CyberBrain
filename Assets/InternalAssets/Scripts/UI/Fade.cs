using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private Image fade;
    [SerializeField] private float animationDuration = 2f;
    
    public static Fade Instance;
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
    }

    public Tween StartFade()
    {
        return fade.DOFade(1,animationDuration);
    }

    public Tween UnFade()
    {
        return fade.DOFade(0,animationDuration);
    }
}
