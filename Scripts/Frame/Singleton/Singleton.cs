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
