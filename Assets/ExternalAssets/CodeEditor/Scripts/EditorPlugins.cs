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
            codeEditor.codeInput.onValidateInput += plugin.OnValidateHandler;
            codeEditor.codeInput.onEndTextSelection.AddListener(plugin.OnEndTextSelection) ;
            //codeEditor.codeInput.onTextSelection.AddListener(plugin.OnEndTextSelection) ;
        }
    }
}

public partial class EditorPlugins
{

    private char OnNewLineValidateHandler(string text, int charindex, char addedchar)
    {
        return addedchar;
    }

    private int GetCountOfNotClosedBrackets(string code, int charIndex)
    {
        var partOfCode = code.Substring(0, charIndex);

        var openBracketsCount = partOfCode.Count(x => Directories.Brackets.ContainsKey(x));
        var closeBracketsCount = partOfCode.Count(x => Directories.Brackets.ContainsValue(x));

        return openBracketsCount - closeBracketsCount;
    }
}