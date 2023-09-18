using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// UI ���,MVC���ģʽ��Control��
    /// �ռ��ؼ��������ֵ䣬������ٲ��Һ�ʹ��
    /// ����UIControlӦ�ü̳д���
    /// </summary>
    public class UIControl : MonoBehaviour
    {
        public List<GameObject> Nodes = new List<GameObject>();
        Dictionary<string, Button> buttons = new Dictionary<string, Button>();
        protected virtual void Awake()
        {
            ForeachNodes();
        }
        /// <summary>
        /// ��������б����뻺���ֵ�
        /// </summary>
        public virtual void ForeachNodes()
        {
            foreach (GameObject node in Nodes)
            {
                if (GetButton(node)) continue;
            }
        }
        
        /// <summary>
        /// ��ȡButton ��ȡ�ɹ�����true
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool GetButton(GameObject obj)
        {
            Button btn = obj.GetComponent<Button>();
            if(btn)
            {
                buttons.Add(obj.name,btn);
                return true;
            }
            return false;
        }
    }
}