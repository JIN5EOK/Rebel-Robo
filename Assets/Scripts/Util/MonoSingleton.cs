using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// By Jinseok Bae
/// <summary>
/// MonoBehaviour를 상속받는 클래스들에 사용할 수 있는 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static object mLock = new object();
    private static T instance = null;
    private static bool mShuttingDown = false;

    public static T Instance
    {
        get
        {
            // 한번에 한 쓰레드만 실행하도록 lock 블럭을 실행한다.
            if(mShuttingDown)
            {
                return null;
            }

            lock(mLock)
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if(instance == null)
                    {
                        var singletonObejct = new GameObject();
                        instance = singletonObejct.AddComponent<T>();
                        singletonObejct.name = typeof(T).ToString() + "(Singleton)";
                        DontDestroyOnLoad(singletonObejct);
                    }
                }

                return instance;
            }
        }
    }
    private void OnApplicationQuit()
    {
        mShuttingDown = true;
    }

    private void OnDestroy()
    {
        mShuttingDown = true;
    }
}
