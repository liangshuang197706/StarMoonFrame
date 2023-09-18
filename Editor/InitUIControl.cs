using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;
using System;

namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// 快速生成UI Control
    /// 上方菜单栏UIControl/InitUIControl 
    /// 点击打开小弹窗
    /// 然后选中制作的预制体根节点
    /// 最后点击生成,即可快速生成脚本
    /// 最后需要手动最小化unity窗口后，然后检索生成.mate文件
    /// </summary>
    public class InitUIControl : EditorWindow
    {
        private string mInputText = "";
        [MenuItem("UIControl/InitUIControl")]
        public static void OpenWindow()
        {
            InitUIControl window = GetWindow<InitUIControl>();
            window.Show();
        }
        private void OnGUI()
        {
            GUILayout.Label($"请选中物体");
            GameObject select = Selection.activeGameObject;
            if (GUILayout.Button("生成Control"))
            {
                if (select != null && select.GetComponent<Canvas>())
                {
                    mInputText = select.name;
                    Init();
                }
                else Debug.LogError("未选中物体 或 UI根节点不存在Canvas组件!");
            }
        }
        private void Init()
        {
            string path = Application.dataPath + $"/Scripts/Game/UI";

            #region 检索文件夹路径

            // UI脚本根节点
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // 创建Mode文件夹
            string mpath = path + $"/{mInputText}/Mode";
            if (!Directory.Exists(mpath))
            {
                Directory.CreateDirectory(mpath);
            }

            // 创建Control文件夹
            path += $"/{mInputText}/Control";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            #endregion

            // 检查文件是否已被生成,防止误覆盖
            path += $"/{mInputText}_UIControl.cs";
            if (File.Exists(path))
            {
                Debug.LogError("文件已存在!");
                return;
            }

            // 创建并写入文件
            using (FileStream createfile = File.Create(path))
            {
                Debug.Log($"创建:{mInputText}_UIControl 完成");
                string data = "";
                data += "using System.Collections;\n";
                data += "using System.Collections.Generic;\n";
                data += "using UnityEngine;\n";
                data += "using UnityEngine.UI;\n";
                data += "using SMF;\n";
                data += ReturnInfo();
                data += $"public class {mInputText}_UIControl : UIControl\n";
                data += "{\n\tprotected override void Awake()\n\t{\n\t\tbase.Awake();\n\t}\n\tprivate void Start()\n\t{\n\t}\n}";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                createfile.Write(bytes);
            }
            Debug.Log($"写入完成");
        }
        public string ReturnInfo()
        {
            string str = "\n/*************************************\n";
            str += "** auth: AUTHER\n";
            str += $"** date: {DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}\n";
            str += "** Version: 0.0.1\n";
            str += "*************************************/\n";
            return str;
        }
    }
}