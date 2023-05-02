using System;
using TMPro;
using UnityEngine;
using Terminal;

public class ConsoleDebug: MonoBehaviour
{
    private static ConsoleDebug instance;
    public TMP_Text _logText;

    public void ResetInstance()
    {
        instance = this;
    }

    public static void Log(object msg)
    {
        if (instance._logText != null)
        {
            instance._logText.text += string.Concat(msg, Environment.NewLine);
        }
    }

    public static void ClearConsole()
    {
        if (instance != null && instance._logText != null)
        {
            instance._logText.text = string.Empty;
        }
    }
}