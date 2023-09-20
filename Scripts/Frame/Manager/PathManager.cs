using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// ������Դ�Ļ���·��
    /// </summary>
    public static class PathManager
    {
        /// <summary>
        /// UI Ԥ���� AB����·��
        /// </summary>
        public static string UIPath= "/AssetBundles/UI/";

        /// <summary>
        /// UI Ԥ���� AB����·��
        /// </summary>
        public static string ConfigPath = "/Config/";

        /// <summary>
        /// ����·���Ƿ���Ч
        /// </summary>
        /// <returns></returns>
        public static bool CheckPath()
        {
            bool check = true;

            // ���UI Ԥ�����·��
            UIPath = Application.streamingAssetsPath + UIPath;
            if (!Directory.Exists(UIPath)) check = false;

            // ��������ļ� ��·��
            ConfigPath = Application.streamingAssetsPath + ConfigPath;
            if (!Directory.Exists(ConfigPath)) check = false;

            return check;
        }
    }
}