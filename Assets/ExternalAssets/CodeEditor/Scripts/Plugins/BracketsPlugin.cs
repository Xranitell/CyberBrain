using System.Collections;
using System.Collections.Generic;
using Terminal;
using Terminal.Plugins;
using UnityEngine;

public class BracketsPlugin : Plugin
{
    public override char OnValidateHandler(string text, int charindex, char addedchar)
    {
        char pairedChar;
        Directories.Brackets.TryGetValue(addedchar, out pairedChar);

        editor.codeInput.text = text.Insert(charindex, pairedChar.ToString());

        return addedchar;
    }
}
