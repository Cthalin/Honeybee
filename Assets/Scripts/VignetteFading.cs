using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class VignetteFading : MonoBehaviour {

    [SerializeField] private PostProcessingProfile _profile;

    //Set start values again
    void Awake()
    {
        //_profile.vignette.enabled = true;
        //VignetteModel.Settings viSettings = _profile.vignette.settings;
        //viSettings.intensity = 1f;
        //_profile.vignette.settings = viSettings;
    }

    //Start Intro Vignette Reduction
    void Start()
    {
        _profile.vignette.enabled = true;
        VignetteModel.Settings viSettings = _profile.vignette.settings;
        viSettings.intensity = 1f;
        _profile.vignette.settings = viSettings;
        IntroVignetteReduction();
    }

    public void IntroVignetteReduction()
    {
        StartCoroutine(DoVignetteReduction());
    }

    IEnumerator DoVignetteReduction()
    {
        float timer = Time.time + 5f;
        VignetteModel.Settings vignetteSettings = _profile.vignette.settings;

        while (vignetteSettings.intensity > 0f)
        {
            vignetteSettings = _profile.vignette.settings;
            vignetteSettings.intensity -= 0.01f;
            _profile.vignette.settings = vignetteSettings;

            if (vignetteSettings.intensity <= 0) _profile.vignette.enabled = false;

            yield return null;
        }

        yield return null;
    }
}
