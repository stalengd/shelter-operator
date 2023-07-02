using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersistentMonoBehaviour<T> : SingletonMonoBehaviour<T> where T : MonoBehaviour
{
    protected override void OnEnable()
    {
        base.OnEnable();

        DontDestroyOnLoad(gameObject);
    }
}
