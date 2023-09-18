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
    /// ��������UI Control
    /// �Ϸ��˵���UIControl/InitUIControl 
    /// �����С����
    /// Ȼ��ѡ��������Ԥ������ڵ�
    /// ���������,���ɿ������ɽű�
    /// �����Ҫ�ֶ���С��unity���ں�Ȼ���������.mate�ļ�
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
            GUILayout.Label($"��ѡ������");
            GameObject select = Selection.activeGameObject;
            if (GUILayout.Button("����Control"))
            {
                if (select != null && select.GetComponent<Canvas>())
                {
                    mInputText = select.name;
                    Init();
                }
                else Debug.LogError("δѡ������ �� UI���ڵ㲻����Canvas���!");
            }
        }
        private void Init()
        {
            string path = Application.dataPath + $"/Scripts/Game/UI";

            #region �����ļ���·��

            // UI�ű����ڵ�
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            // ����Mode�ļ���
            string mpath = path + $"/{mInputText}/Mode";
            if (!Directory.Exists(mpath))
            {
                Directory.CreateDirectory(mpath);
            }

            // ����Control�ļ���
            path += $"/{mInputText}/Control";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            #endregion

            // ����ļ��Ƿ��ѱ�����,��ֹ�󸲸�
            path += $"/{mInputText}_UIControl.cs";
            if (File.Exists(path))
            {
                Debug.LogError("�ļ��Ѵ���!");
                return;
            }

            // ������д���ļ�
            using (FileStream createfile = File.Create(path))
            {
                Debug.Log($"����:{mInputText}_UIControl ���");
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
            Debug.Log($"д�����");
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