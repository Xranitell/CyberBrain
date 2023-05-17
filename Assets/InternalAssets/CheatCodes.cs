using System;
using System.Collections;
using System.Collections.Generic;
using Terminal;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
    private CodeEditor[] _allEditors;
    private void Awake()
    {
        _allEditors  = CodeEditor.FindObjectsOfType<CodeEditor>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightControl))
        {
            foreach (var editor in _allEditors)
            {
                editor.SetSolved();
            }
        }
    }
}
