using System;
using TMPro;
using UnityEngine;

namespace Terminal.Plugins
{
    public abstract class Plugin: MonoBehaviour
    {
        public static CodeEditor editor;

        public virtual char OnValidateHandler(string text, int charindex, char addedchar)
        {
            return '\0';
        }
        public virtual void OnEndTextSelection(string a, int b,int c){}
    }
}