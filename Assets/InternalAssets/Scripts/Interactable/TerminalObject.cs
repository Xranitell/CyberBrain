using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Terminal;
using Terminal.Plugins;
using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalObject : MonoBehaviour, IInteractable
{
    public CodeEditor codeEditor;
    public ConsoleDebug debug;
    
    [SerializeField] private Transform cameraPosition;
    private Camera _playerCamera;

    public static bool InTerminal = false;
    
    public void Interact()
    {
        debug.ResetInstance();

        codeEditor.OnExecute ??= ConsoleDebug.Log;

        Plugin.editor = codeEditor;

        _playerCamera = PlayerMainScript.Instance.playerCamera;
        
        _playerCamera.transform.DOMove(cameraPosition.position, 1);
        _playerCamera.transform.DORotateQuaternion(cameraPosition.rotation, 1);
        
        ChangeEnabledStateForComponents(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        InTerminal = true;
    }

    public string GetDescription()
    {
        return "Нажмите <color=blue>[E]</color> для открытия терминала";
    }
    public void CloseTerminal()
    {
        //Activate all components
        EventSystem.current.SetSelectedGameObject(null);

        _playerCamera = PlayerMainScript.Instance.playerCamera;
        
        DOTween.Sequence()
            .Append(_playerCamera.transform.DOMove(PlayerMainScript.Instance.cameraPosition.position, 1))
            .Append(_playerCamera.transform.DORotateQuaternion(PlayerMainScript.Instance.cameraPosition.rotation, 0.2f))
            .AppendCallback(()=>
            {
                Cursor.visible = false;
                ChangeEnabledStateForComponents(true);
                Cursor.lockState = CursorLockMode.Locked;
                InTerminal = false;
            })
        ;
    }

    private void ChangeEnabledStateForComponents(bool isEnabled)
    {
        var playerScript = PlayerMainScript.Instance;
        playerScript.playerMovement.enabled = isEnabled;
        playerScript.playerInteraction.enabled = isEnabled;
        playerScript.playerInteraction.interactionUI.SetActive(isEnabled);
        playerScript.mouseComponent.enabled = isEnabled;
    }
    
    
}
