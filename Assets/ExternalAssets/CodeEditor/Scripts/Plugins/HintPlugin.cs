using System;
using System.Reflection;
using System.Text;
using Terminal.Plugins;
using TMPro;
using UnityEngine;

public class HintPlugin : Plugin
{
    [SerializeField] private TMP_Text hintText;

    public override void OnEndTextSelection(string fullText, int b, int c)
    {
        StringBuilder msg = new StringBuilder();
        
        Type type = Type.ReflectionOnlyGetType(editor.correctCode,true,false);

        if (type != null)
        {
            msg.Append("Имя: " + type.Name + "\n");
            msg.Append("Пространство имен: " + type.Namespace + "\n");

            // Получаем члены типа (поля, свойства, методы и т.д.)
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                msg.Append("Член: " + member.Name + "\n");
                msg.Append("Тип члена: " + member.MemberType + "\n");
            }
        }

        hintText.text = msg.ToString();
    }
}
