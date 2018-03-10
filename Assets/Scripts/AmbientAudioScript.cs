using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudioScript : MonoBehaviour {

    public static AmbientAudioScript instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
