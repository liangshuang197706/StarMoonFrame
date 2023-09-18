using UnityEngine;
namespace SMF
{
    /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// 可以挂载到unity物体上的泛型单例
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
                    // 双重锁，保证线程安全.
                    lock (mLockObject)
                    {
                        // 在场景中查找是否存在实例
                        mInstance = FindObjectOfType<T>();
                        if (mInstance == null)
                        {
                            // 生成空物体，以T类名命名，并加上实例组件.
                            GameObject singleton = new GameObject(typeof(T).Name);
                            mInstance = singleton.AddComponent<T>();
                        }
                    }
                }
                return mInstance;
            }
        }
        /// <summary>
        /// 在Awake中进行判断，保证场景中只有一个实例.
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