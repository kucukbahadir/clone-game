using System;
using UnityEngine;

[DisallowMultipleComponent]
public class MonoBehaviourSingleton<T>: MonoBehaviour where T : class
{
    public static T Instance;
    
    protected virtual void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        
        Instance = gameObject.GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}
