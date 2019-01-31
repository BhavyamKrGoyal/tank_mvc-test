using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                DontDestroyOnLoad(instance);
            }
            else 
            {
                //Destroy(this);
                Debug.LogError("Creating a duplicate instance of a Sinleton");
            }

            return instance;
        }
    }




}
