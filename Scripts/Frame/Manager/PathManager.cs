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
    /// 配置资源的基本路径
    /// </summary>
    public static class PathManager
    {
        /// <summary>
        /// UI 预制体 AB包根路径
        /// </summary>
        public static string UIPath= "/AssetBundles/UI/";

        /// <summary>
        /// UI 预制体 AB包根路径
        /// </summary>
        public static string ConfigPath = "/Config/";

        /// <summary>
        /// 检查根路径是否有效
        /// </summary>
        /// <returns></returns>
        public static bool CheckPath()
        {
            bool check = true;

            // 检查UI 预制体根路径
            UIPath = Application.streamingAssetsPath + UIPath;
            if (!Directory.Exists(UIPath)) check = false;

            // 检查配置文件 根路径
            ConfigPath = Application.streamingAssetsPath + ConfigPath;
            if (!Directory.Exists(ConfigPath)) check = false;

            return check;
        }
    }
}