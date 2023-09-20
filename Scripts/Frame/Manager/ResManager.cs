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
    /// ��Դ����ģ��
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
        /// AB����Դ�ļ���
        /// </summary>
        private const string RESOURCE_ROOT_PATH = "/AssetBundles/";

        /// <summary>
        /// ��Դ����
        /// ע�⣺�뼰ʱж�ز����õ���Դ,��ֹ�ڴ�й©
        /// </summary>
        private Dictionary<string, Object> mResCacheDictionary = new Dictionary<string, Object>();
        public T LoadAssetBundle<T>(string resPath, string name) where T : Object
        {
            if (mResCacheDictionary.ContainsKey(name) && mResCacheDictionary[name] != null) return mResCacheDictionary[name] as T;
            AssetBundle ab = AssetBundle.LoadFromMemory(File.ReadAllBytes(Application.streamingAssetsPath + RESOURCE_ROOT_PATH + resPath));
            T obj = ab.LoadAsset(name) as T;
            // ж�� AssetBundle
            ab.Unload(false);
            if (obj == null)
            {
                string errorMessage = ColorText.SampleColorText(ColorText.SampleColorEnum.Red, "ָ��AssetBundleΪ��!");
                Debug.LogError(errorMessage);
                return null;
            }
            mResCacheDictionary.Add(name, obj);
            return obj;
        }
        public IEnumerator AsyncLoadAssetBundle<T>(string resPath, string name, UnityAction<T> action) where T : Object
        {
            AssetBundleCreateRequest abRequest = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(Application.streamingAssetsPath + RESOURCE_ROOT_PATH + resPath));
            // �ȴ���ȡ���
            yield return abRequest;
            T obj = abRequest.assetBundle.LoadAsset<T>(name);
            action(obj);
            yield return null;
        }

    }
}