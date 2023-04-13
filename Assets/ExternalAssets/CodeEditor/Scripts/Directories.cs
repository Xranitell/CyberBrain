using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Terminal
{
    public class Directories
    {
        public static List<string> Refferences = new()
        {
            "System.dll",
            Assembly.GetAssembly(typeof(Behaviour)).Location,
            Assembly.GetAssembly(typeof(DataHolder)).Location,
            Assembly.GetAssembly(typeof(CodeEditor)).Location,
        };

        public static Dictionary<char, char> Brackets = new()
        {
            { '[', ']' },
            { '{', '}' },
            { '(', ')' },
            { '"', '"' }
        };
    }
}