using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// 资源管理模块
    /// </summary>
    public class ResManager : UnitySingleton<ResManager>
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

        /// <summary>
        /// AB包资源文件夹
        /// </summary>
        private const string RESOURCE_ROOT_PATH = "/AssetBundles/";

        /// <summary>
        /// 资源缓存
        /// 注意：请及时卸载不常用的资源,防止内存泄漏
        /// </summary>
        private Dictionary<string, Object> mResCacheDictionary = new Dictionary<string, Object>();
        public T LoadAssetBundle<T>(string resPath, string name) where T : Object
        {
            if (mResCacheDictionary.ContainsKey(name) && mResCacheDictionary[name] != null) return mResCacheDictionary[name] as T;
            AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(Application.streamingAssetsPath + RESOURCE_ROOT_PATH + resPath));
            T obj = ab.LoadAsset(name) as T;
            // 卸载 AssetBundle
            ab.Unload(false);
            if (obj == null)
            {
                string errorMessage = ColorText.SampleColorText(ColorText.SampleColorEnum.Red, "指定AssetBundle为空!");
                Debug.LogError(errorMessage);
                return null;
            }
            mResCacheDictionary.Add(name, obj);
            return obj;
        }
        public IEnumerator AsyncLoadAssetBundle<T>(string resPath, string name, UnityAction<T> action) where T : Object
        {
            AssetBundleCreateRequest abRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(Application.streamingAssetsPath + RESOURCE_ROOT_PATH + resPath));
            // 等待读取完毕
            yield return abRequest;
            T obj = abRequest.assetBundle.LoadAsset<T>(name);
            action(obj);
            yield return null;
        }

    }
}