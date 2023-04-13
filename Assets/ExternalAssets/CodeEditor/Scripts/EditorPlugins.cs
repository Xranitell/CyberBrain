using System.Linq;
using Terminal;
using TMPro;
using UnityEngine;

//MainPart
public partial class EditorPlugins : MonoBehaviour
{
    public CodeEditor codeEditor;
    private TMP_InputField _input;

    private void Awake()
    {
        _input = codeEditor.codeInput;
        //_input.onValueChanged.AddListener(null);
        _input.onValidateInput += OnBracketsValidateHandler;
        _input.onValidateInput += OnNewLineValidateHandler;
    }
}

//Pair Brakes 
public partial class EditorPlugins
{
    private char OnBracketsValidateHandler(string text, int charindex, char addedchar)
    {
        char pairedChar;
        Directories.Brackets.TryGetValue(addedchar, out pairedChar);

        _input.text = text.Insert(charindex, pairedChar.ToString());

        return addedchar;
    }
}

//tab handler
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