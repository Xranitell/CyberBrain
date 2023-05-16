using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        Fade.Instance.UnFade();
    }

    public void ContinueButton()
    {
        LoadScene();
    }

    public void NewGameButton()
    {
        SaveLoadSystem.SaveLastPosition(new Vector3(-20,2,-5));
        LoadScene();
    }

    private void LoadScene()
    {
        DOTween.Sequence()
            .Append(Fade.Instance.StartFade())
            .AppendCallback(()=>SceneManager.LoadScene("GameScene"));
    }
    
    public void QuitGame()
    {
        DOTween.Sequence()
            .Append(Fade.Instance.StartFade())
            .AppendCallback(()=>Application.Quit());
    }
}
