using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class HoneycombScript : MonoBehaviour {

    [SerializeField] private GameObject gameManager;

    [SerializeField] private GameObject _honeycombLid;
    [SerializeField] private GameObject _outsideLight;
    [SerializeField] private GameObject _fadeCanvas;

    [SerializeField] private float _howLongToDo = 0.2f;

    [SerializeField] private float _howMuchToAddToIntensity = 0.01f;

    [SerializeField] private PostProcessingProfile _profile;

    public void ChangePPProfile()
    {
        // TBD Change PPProfile Settings based on how far lid is pushed
       StartCoroutine(DoPPPChange());
    }

    IEnumerator DoPPPChange()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            BloomModel.Settings bloomSettings = _profile.bloom.settings;
            bloomSettings.bloom.intensity += 0.01f;
            _profile.bloom.settings = bloomSettings;

            yield return null;
        }

        yield return null;
    }

    public void ChangeLight()
    {
        StartCoroutine(DoLightChange());
    }

    IEnumerator DoLightChange()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            _outsideLight.GetComponent<Light>().intensity += _howMuchToAddToIntensity;

            yield return null;
        }

        yield return null;
    }

    //Set start values again
    void Awake()
    {
        if (GameManager.instance == null)
            //Instantiate gameManager prefab
            Instantiate(gameManager);

        BloomModel.Settings bloomSettings = _profile.bloom.settings;
        bloomSettings.bloom.intensity = 0.5f;
        _profile.bloom.settings = bloomSettings;
    }

    public void SendFadeRequestToGameManager()
    {
        gameManager.GetComponent<GameManager>().FadeIntoWhite(_fadeCanvas);
    }
}