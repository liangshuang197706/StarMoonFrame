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
    /// ���Ի���־��ӡ����
    /// </summary>
    public class LogUtil : MonoBehaviour
    {
        /// <summary>
        /// ���������־��ӡ��ʽ
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
