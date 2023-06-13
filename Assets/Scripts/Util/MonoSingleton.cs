using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// MonoBehaviour를 상속받는 클래스들에 사용할 수 있는 싱글톤
/// </summary>
/// <typeparam name="T"></typeparam>
public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;
    public static T Instance
    {
        get 
        {
            if (instance == null)
            {
                var obj = GameObject.FindObjectOfType<T>();
                if(obj == null)
                {
                    var newObj = new GameObject(typeof(T).Name).AddComponent<T>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if(instance == null) instance = this as T;
        else
        {
            if(instance != this) Destroy(gameObject);
        }
    }
}

public class Singleton<T> where T : class, new()
{
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
                instance = new T();

            return instance;
        }
    }
}
