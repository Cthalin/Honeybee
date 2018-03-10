using System;
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

    /*
    * TBD
    * Fade to White
    * Deactivate player input
    * Load next scene
    */

    public void FadeIntoWhite(GameObject canvas)
    {
        try
        {
            canvas.GetComponent<FadeScript>().FadeIn();
        }
        catch (Exception e)
        {
            Debug.Log("Error: "+e);
        }
        //Debug.Log("Fade to white");
    }

    public void DeactivatePlayerInput()
    {
        Debug.Log("Deactivate player input");
    }

    public void LoadScene(String scene)
    {
        Debug.Log("Load scene: "+scene);
    }


}
