using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class HoneycombScript : MonoBehaviour {

    [SerializeField] private GameObject _honeycombLid;
    [SerializeField] private GameObject _outsideLight;

    [SerializeField] private float _howLongToDo = 0.2f;
    [SerializeField] private float _howLongToWait = 2f;
    [SerializeField] private float _howFarToMove = 0.02f;
    [SerializeField] private float _howMuchToAddToIntensity = 0.1f;

    [SerializeField] private PostProcessingProfile _profile;

    private Boolean _isBlockedForMove = false;
    private LidState _stateOfLid = LidState.CLOSED;

    private enum LidState
    {
        CLOSED,
        PUSHED1,
        PUSHED2,
        PUSHED3,
        OPEN
    }

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
       StartCoroutine(DoPPPChange());
    }

    IEnumerator DoPPPChange()
    {
        float timer = Time.time + _howLongToDo;

        while (Time.time < timer)
        {
            BloomModel.Settings bloomSettings = _profile.bloom.settings;
            bloomSettings.bloom.intensity += 0.1f;
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
            vignetteSettings.intensity -= 0.001f;
            _profile.vignette.settings = vignetteSettings;

            if (vignetteSettings.intensity <= 0) _profile.vignette.enabled = false;

            yield return null;
        }

        yield return null;
    }

    //Set start values again
    void OnEnable()
    {
        BloomModel.Settings bloomSettings = _profile.bloom.settings;
        bloomSettings.bloom.intensity = 0.5f;
        _profile.bloom.settings = bloomSettings;

        _profile.vignette.enabled = true;
        VignetteModel.Settings viSettings = _profile.vignette.settings;
        viSettings.intensity = 1f;
        _profile.vignette.settings = viSettings;
    }

    //Start Intro Vignette Reduction
    void Start()
    {
        IntroVignetteReduction();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "target" && _isBlockedForMove == false)
                {
                    //Move();
                    //ChangePPProfile();
                    //ChangeLight();
                    StartCoroutine(FixedWait());
                    ChangeLidState();
                }
            }
        }
    }

    IEnumerator FixedWait()
    {
        float timer = Time.time + _howLongToWait;

        while (Time.time < timer)
        {
            _isBlockedForMove = true;
            yield return null;
        }

        _isBlockedForMove = false;
        yield return null;
    }

    public void PlayAnimation(String animName)
    {
        _honeycombLid.GetComponent<Animator>().Play(animName);
    }

    public void ChangeLidState()
    {
        switch (_stateOfLid)
        {
            case LidState.CLOSED:
                _stateOfLid = LidState.PUSHED1;
                PlayAnimation("LidWobble");
                break;

            case LidState.PUSHED1:
                _stateOfLid = LidState.PUSHED2;
                PlayAnimation("LidPushFirst");
                break;

            case LidState.PUSHED2:
                _stateOfLid = LidState.PUSHED3;
                PlayAnimation("LidPushSecond");
                break;

            case LidState.PUSHED3:
                _stateOfLid = LidState.OPEN;
                PlayAnimation("LidPushSecond");
                break;

            case LidState.OPEN:
                PlayAnimation("LidPushThird");
                break;

            default: break;
        }
    }
}