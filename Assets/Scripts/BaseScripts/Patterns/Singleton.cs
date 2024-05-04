using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// SingletoneBase instance back field
    /// </summary>
    private static T instance = null;
    /// <summary>
    /// SingletoneBase instance
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(T)) as T;
                if (instance == null)
                    Debug.LogError("SingletoneBase<T>: Could not found GameObject of type " + typeof(T).Name);
            }
            return instance;
        }
    }
}

