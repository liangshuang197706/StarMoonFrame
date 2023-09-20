using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// ��Ϸ��Ч����ģ��
    /// </summary>
    public class AudioManager : UnitySingleton<AudioManager>
    {
        public bool init = false;
        /// <summary>
        /// ��Ϸ��Ƶ�����
        /// </summary>
        public AudioMixer AM
        {
            get
            {
                return audioMixer;
            }
        }

        private AudioMixer audioMixer;
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
        /// ���ò�ͬ�����µ���Ƶ����
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="value"></param>
        public void SetVolue(string Name,float value)
        {
            audioMixer.SetFloat(Name,value);
        }
        /// <summary>
        /// ��ȡ��Ƶ�����в�ͬ��Ƶ��������С
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public float GetVolue(string Name)
        {
            float value = 0;
            audioMixer.GetFloat(Name,out value);
            return value;
        }

    }
}