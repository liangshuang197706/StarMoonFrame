namespace SMF
{
     /*************************************
     ** auth: Liangshuang
     ** date: 2023/9/18
     ** Version: 0.0.1
     *************************************/

    /// <summary>
    /// ��ͨ���͵���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : new()
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
                        if (mInstance == null)
                            mLockObject = new T();
                    }
                }
                return mInstance;
            }
        }
    }
}
