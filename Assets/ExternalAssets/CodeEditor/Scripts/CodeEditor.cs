using System;
using System.CodeDom.Compiler;
using System.Text;
using Microsoft.CSharp;
using UnityEngine;
using NaughtyAttributes;
using TMPro;
using UCompile;
using UnityEngine;

namespace Terminal
{
    public delegate void ExecuteLogHandler(object message);
    public class CodeEditor : MonoBehaviour
    {
        public ExecuteLogHandler OnExecute;

        public TMP_InputField codeInput;

        [BoxGroup("ExecutableParams")] [SerializeField] string className;
        [BoxGroup("ExecutableParams")] [SerializeField] string methodName;
        
        //Стартовый шаблон кода
        [ResizableTextArea] public string codeTemplate;

        public string correctCode
        {
            get
            {
                return FormatCode(codeInput.text);
            }
        }
        private void Awake()
        {
            ResetTemplate();
            codeInput.caretColor = Color.green;
        }

        public void RunCode() => InvokeAssemblyMethod(className, methodName);

        public void ResetTemplate()
        {
            codeInput.text = codeTemplate;
            ConsoleDebug.ClearConsole();
        }

        private void InvokeAssemblyMethod(string className, string methodName)
        {
            ConsoleDebug.ClearConsole();

            CSScriptEngine engine = new CSScriptEngine();
            
            engine.AddUsings("using Terminal; using UnityEngine; using Laboratory;");

            engine.CompileType(className, correctCode);
            
            engine.AddOnCompilationFailedHandler(OnCompilationFailedAction);
            engine.AddOnCompilationSucceededHandler(OnCompilationSucceededAction);
            
            IScript result = engine.CompileCode($"{className} sm = new {className}();sm.{methodName}();");
            result.Execute();
            
            engine.RemoveOnCompilationFailedHandler(OnCompilationFailedAction);
            engine.RemoveOnCompilationSucceededHandler(OnCompilationSucceededAction);
            
        }
        
        public void OnCompilationSucceededAction(CompilerOutput output)
         {
             var msg = new StringBuilder();
             
             foreach (var error in output.Warnings)
                 msg.AppendFormat("Warning: ({0})\n", error);
             OnExecute?.Invoke("<color=yellow>" + msg + "</color>");
             
             OnExecute.Invoke("<color=green>Успешно!</color>...");
         }
         public void OnCompilationFailedAction(CompilerOutput output)
         {
             if (output.Errors.Count > 0)
             {
                 OnExecute?.Invoke("<color=red>Ошибка компиляции...</color>");
                 var msg = new StringBuilder();
             
                 foreach (var error in output.Errors)
                     msg.AppendFormat("Error: ({0})\n", error);
             
                 OnExecute?.Invoke("<color=red>" + msg + "</color>");
             }
         }
        public static string FormatCode(string code)
        {
            return code;
        }
    }    
}