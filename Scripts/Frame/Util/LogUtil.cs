using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SMF
{
    /*************************************
    ** auth: Liangshuang
    ** date: 2023/9/18
    ** Version: 0.0.1
    *************************************/

    /// <summary>
    /// 个性化日志打印工具
    /// </summary>
    public class LogUtil : MonoBehaviour
    {
        /// <summary>
        /// 最基本的日志打印方式
        /// Debug.Log()
        /// </summary>
        /// <param name="info">string :s</param>
        public static void SampleLog(string info)
        {
            Debug.Log("<color=#FFE1FF>Log </color>: <color=#00FFFF>" + info + "</color>");
        }

        public static void Success(string info)
        {
            Debug.Log("<color=#FFE1FF>Log </color>: <color=#7FFF00>" + info + "</color>");
        }

        public static void Warning(string info)
        {
            Debug.Log("<color=#FFE1FF>Log </color>: <color=yellow>" + info + "</color>");
        }

        public static void Danger(string info)
        {
            Debug.Log("<color=#FFE1FF>Log </color>: <color=red>" + info + "</color>");
        }
    }
}
