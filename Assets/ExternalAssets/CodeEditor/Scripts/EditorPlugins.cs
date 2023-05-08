using System.Collections.Generic;
using System.Linq;
using Terminal;
using Terminal.Plugins;
using TMPro;
using UnityEngine;

//MainPart
public partial class EditorPlugins : MonoBehaviour
{
    public List<Plugin> plugins = new List<Plugin>();
    [SerializeField] CodeEditor codeEditor;

    private void Awake()
    {
        foreach (var plugin in plugins)
        {
            //codeEditor.codeInput.onValidateInput += plugin.OnValidateHandler;
            //codeEditor.codeInput.onEndTextSelection.AddListener(plugin.OnEndTextSelection) ;
            //codeEditor.codeInput.onTextSelection.AddListener(plugin.OnEndTextSelection) ;
        }
    }
}