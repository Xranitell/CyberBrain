using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpsManager : MonoBehaviour
{
    public Image pausePopUp;
    public GameObject popUpElements;
    
    public Image fade;

    [SerializeField] private float animationDurantion;

    private void Start()
    {
        fade.material.color = Color.black;
        fade.DOFade(0, animationDurantion);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !TerminalObject.InTerminal)
        {
            Debug.Log("Open");

            pausePopUp.DOFade(.5f, animationDurantion);
            popUpElements.transform.DOScale(Vector3.one, animationDurantion);
            PlayerMainScript.Instance.mouseComponent.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            EventSystem.current.SetSelectedGameObject(null);
        }
    }


    public void ExitGame()
    {
        DOTween.Sequence()
            .Append(fade.DOFade(1, animationDurantion))
            .Append(popUpElements.transform.DOScale(Vector3.zero, animationDurantion))
            .AppendCallback(()=>Application.Quit());
    }

    public void ContinueGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        pausePopUp.DOFade(0, animationDurantion);
        popUpElements.transform.DOScale(Vector3.zero, animationDurantion);
        PlayerMainScript.Instance.mouseComponent.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadSave()
    {
        DOTween.Sequence()
            .Append(fade.DOFade(1, animationDurantion))
            .Append(popUpElements.transform.DOScale(Vector3.zero, animationDurantion))
            .AppendCallback(()=>SceneManager.LoadScene("GameScene"));
    }
    
}
