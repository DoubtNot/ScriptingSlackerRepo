using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance = null;
    void Awake() 
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this) 
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
