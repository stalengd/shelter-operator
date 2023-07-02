using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T Instance 
    { 
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
            }

            return instance;
        }
    }
    private static T instance;

    protected virtual void OnEnable()
    {
        if (instance != null)
        {
            if (instance == this) 
                return;

            Debug.Log($"Instance of singleton type '{typeof(T).Name}' already exists, destroing duplication");
            Destroy(gameObject);

            return;
        }

        instance = this as T;
    }

    public static void ClearInstance()
    {
        Destroy(Instance.gameObject);
    }
}
