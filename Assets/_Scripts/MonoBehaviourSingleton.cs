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
            Debug.LogWarning($"The {gameObject.GetComponent<T>()} already exist in the scene " + gameObject.name);
            Destroy(gameObject);
        }
        
        Instance = gameObject.GetComponent<T>();
    }
}
