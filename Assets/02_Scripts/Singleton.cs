using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = (T)FindObjectOfType(typeof(T));

            if (Instance == null)
            {
                GameObject singletonObject = new GameObject();
                Instance = singletonObject.AddComponent<T>();
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(Instance);
    }
}
