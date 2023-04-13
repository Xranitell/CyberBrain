using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Terminal
{
    public delegate void ExecuteLogHandler(object message);
    public class CodeEditor : MonoBehaviour
    {
        public static CodeEditor Instance;
        public TMP_InputField codeInput;
        [SerializeField] private TMP_Text logText;

        [BoxGroup("ExecutableParams")] [SerializeField]
        private string className;

        [BoxGroup("ExecutableParams")] [SerializeField]
        private string methodName;

        [BoxGroup("NotFormatedCode")] [ResizableTextArea] [SerializeField]
        private string savedCode;


        public ExecuteLogHandler OnExecute;

        private void Start()
        {
            codeInput.text = savedCode;
        }

        public void RunCode()
        {
            StartCoroutine(RunCodeCoroutine());
        }

        private IEnumerator RunCodeCoroutine()
        {
            OnExecute += Log;
            logText.text = string.Empty;
            Instance = this;
            var code = FormatCode(codeInput.text);

            var assembly = Compile(code);
            var method = assembly.GetType(className).GetMethod(methodName);
            var del = (Action)Delegate.CreateDelegate(typeof(Action), method);
            
            del.Invoke();
            yield break;
        }

        private string FormatCode(string codeInputText)
        {
            return codeInputText;
        }

        public static Assembly Compile(string source)
        {
            var provider = new CSharpCodeProvider();
            var param = new CompilerParameters();

            // Add ALL of the assembly references
            /*foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
                param.ReferencedAssemblies.Add(assembly.Location);*/

            // Add specific assembly references
            param.ReferencedAssemblies.AddRange(Directories.Refferences.ToArray());

            // Generate a dll in memory
            param.GenerateExecutable = false;
            param.GenerateInMemory = true;

            // Compile the source
            var result = provider.CompileAssemblyFromSource(param, source);

            if (result.Errors.Count > 0)
            {
                var msg = new StringBuilder();
                foreach (CompilerError error in result.Errors)
                    msg.AppendFormat("Error ({0}): {1}\n",
                        error.ErrorNumber, error.ErrorText);
                throw new Exception(msg.ToString());
            }

            // Return the assembly
            return result.CompiledAssembly;
        }

        public void Log(object msg)
        {
            logText.text += string.Concat(msg, Environment.NewLine);
        }
    }    
}