using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
        SceneManager.LoadScene(scene);
        Debug.Log("Load scene: "+scene);
    }

    //public void Quit()
    //{
    //    #if UNITY_EDITOR
    //            UnityEditor.EditorApplication.isPlaying = false;
    //    #else
    //            Application.Quit();
    //    #endif
    //}

    //public void SaveGame()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

    //    PlayerData playerData = new PlayerData();
    //    playerData.scene = SceneManager.GetActiveScene().name;

    //    bf.Serialize(file, playerData);
    //    file.Close();
    //}

    //public void LoadGame()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file;

    //    if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
    //    {
    //        file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
    //        PlayerData playerData = (PlayerData)bf.Deserialize(file);
    //        SceneManager.LoadScene(playerData.scene);
    //    }
    //    else
    //    {
    //        file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
    //        PlayerData playerData = new PlayerData();
    //        playerData.scene = SceneManager.GetActiveScene().name;

    //        bf.Serialize(file, playerData);
    //    }

    //    file.Close();
    //}

    //[Serializable]
    //class PlayerData
    //{
    //    public String scene;
    //}
}
