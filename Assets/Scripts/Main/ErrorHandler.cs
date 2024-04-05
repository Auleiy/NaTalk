// #undef UNITY_EDITOR

using System.Threading;
using UnityEditor;
using UnityEngine;
using static NPT.Main.StaticValue;

namespace NPT.Main
{
    public class ErrorHandler : MonoBehaviour
    {
        private int ErrorCount = 0;

        private void Start()
        {
            Application.logMessageReceived += Catch;
            Thread t = new(FlushErrorCount);
            t.Start();
        }

        private void Catch(string content, string stc, LogType type)
        {
            switch (type)
            {
                case LogType.Error: MainTipContainer.Create($"发生错误：{content}", TipType.Error); ErrorCount++; break;
                case LogType.Assert: MainTipContainer.Create($"发生错误：{content}", TipType.Error); ErrorCount++; break;
                case LogType.Exception: MainTipContainer.Create($"抛出异常：{content}", TipType.Error); ErrorCount++; break;
                default: break;
            }
            if (ErrorCount >= 10)
#if UNITY_EDITOR
            {
                Debug.LogError("0.1秒内截获超过10次错误，已强制退出");
                EditorApplication.ExitPlaymode();
            }
#else
            {
                Application.Quit(1);
            }
#endif
        }

        private void FlushErrorCount()
        {
            while (true)
            {
                ErrorCount = 0;
                Thread.Sleep(100);
            }
        }
    }
}
