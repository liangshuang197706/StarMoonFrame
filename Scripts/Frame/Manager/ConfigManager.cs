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
    /// ���ù���ģ��
    /// </summary>
    public class ConfigManager : UnitySingleton<ConfigManager>
    {
        public bool init = false;

        private void Start()
        {
            StartCoroutine(InitManager());
        }
        IEnumerator InitManager()
        {
            yield return null;
            LogUtil.SampleLog($"{gameObject.name} Init Success!");
            init = true;
        }
        private void OnDestroy()
        {
            LogUtil.Danger($"{gameObject.name} Destory !");
        }
    }
}
