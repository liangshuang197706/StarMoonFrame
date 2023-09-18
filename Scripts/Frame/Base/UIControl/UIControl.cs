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
    /// UI 框架,MVC设计模式，Control层
    /// 收集关键结点放入字典，方便快速查找和使用
    /// 所有UIControl应该继承此类
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
        /// 遍历结点列表，存入缓存字典
        /// </summary>
        public virtual void ForeachNodes()
        {
            foreach (GameObject node in Nodes)
            {
                if (GetButton(node)) continue;
            }
        }
        
        /// <summary>
        /// 获取Button 获取成功返回true
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