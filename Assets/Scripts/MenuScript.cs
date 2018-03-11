using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [SerializeField] private GameObject _saveButton;
    [SerializeField] private GameObject _mainMenuPanel;

	// Use this for initialization
	void Start () {
	    if (SceneManager.GetActiveScene().name == "Main")
	    {
            _saveButton.SetActive(false);
            _mainMenuPanel.SetActive(true);
	    }
	}

    void Update()
    {
        if (Input.GetKeyDown("escape") && SceneManager.GetActiveScene().name != "Main")
        {
            if (_mainMenuPanel.activeSelf == false)
            {
                _mainMenuPanel.SetActive(true);
            }
            else
            {
                _mainMenuPanel.SetActive(false);
            }
        }
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData playerData = new PlayerData();
        playerData.scene = SceneManager.GetActiveScene().name;

        bf.Serialize(file, playerData);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)bf.Deserialize(file);
            SceneManager.LoadScene(playerData.scene);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            PlayerData playerData = new PlayerData();
            playerData.scene = SceneManager.GetActiveScene().name;

            bf.Serialize(file, playerData);
        }

        file.Close();
    }

    [Serializable]
    class PlayerData
    {
        public String scene;
    }
}
