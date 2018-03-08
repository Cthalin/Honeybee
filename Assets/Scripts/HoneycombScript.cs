using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class HoneycombScript : MonoBehaviour {

    [SerializeField]
    private GameObject _honeycombLid;
    [SerializeField]
    private GameObject _outsideLight;

    [SerializeField]
    private float _howLongToDo = 0.2f;
    [SerializeField]
    private float _howFarToMove = 0.02f;
    [SerializeField]
    private float _howMuchToAddToIntensity = 0.1f;

    [SerializeField]
    private PostProcessingProfile _profile;

    public void Move()
    {
        StartCoroutine(DoMove());
    }

    IEnumerator DoMove()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            _honeycombLid.transform.position = new Vector3(_honeycombLid.transform.position.x, _honeycombLid.transform.position.y, _honeycombLid.transform.position.z + _howFarToMove);

            yield return null;
        }

        //canvasGroup.interactable = false;
        yield return null;
    }

    public void ChangePPProfile()
    {
        // TBD Change PPProfile Settings based on how far lid is pushed
        DoPPPChange();
    }

    IEnumerator DoPPPChange()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            BloomModel.Settings bloomSettings = _profile.bloom.settings;
            bloomSettings.bloom.intensity += 1f;
            _profile.bloom.settings = bloomSettings;

            VignetteModel.Settings vignetteSettings = _profile.vignette.settings;
            vignetteSettings.intensity += 1f;
            _profile.vignette.settings = vignetteSettings;

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

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.tag == "target")
                {
                    Move();
                    ChangePPProfile();
                    ChangeLight();
                }
            }
        }

        var vignette = _profile.vignette.settings;
        vignette.smoothness = Mathf.Abs(Mathf.Sin(Time.realtimeSinceStartup) * 0.99f) + 0.01f;
        _profile.vignette.settings = vignette;
    }
}
