using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void FadeIntoWhite()
    {
        /*
         * TBD
         * Fade to White
         * Deactivate player input
         * Load next scene
         */

        Debug.Log("Fade to white");
    }
}
