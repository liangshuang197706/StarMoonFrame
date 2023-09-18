using UnityEngine;
namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// ���Թ��ص�unity�����ϵķ��͵���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T mInstance;
        private static object mLockObject = new object();

        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    // ˫��������֤�̰߳�ȫ.
                    lock (mLockObject)
                    {
                        // �ڳ����в����Ƿ����ʵ��
                        mInstance = FindObjectOfType<T>();
                        if (mInstance == null)
                        {
                            // ���ɿ����壬��T����������������ʵ�����.
                            GameObject singleton = new GameObject(typeof(T).Name);
                            mInstance = singleton.AddComponent<T>();
                        }
                    }
                }
                return mInstance;
            }
        }
        /// <summary>
        /// ��Awake�н����жϣ���֤������ֻ��һ��ʵ��.
        /// </summary>
        protected virtual void Awake()
        {
            if (mInstance == null)
            {
                mInstance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}