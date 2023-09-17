/// <summary>
/// 普通泛型单例
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
                // 双重锁，保证线程安全.
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
