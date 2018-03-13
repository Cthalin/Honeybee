using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour {

    [SerializeField] AudioClip[] _guideSteps = new AudioClip[7];
    [SerializeField] private float _initWait = 3f;
    private AudioSource _audioSource;
    private int _clipIndex = 0;
    private bool _isWaiting;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        changeAudioClip(_clipIndex); //Start with first guide clip
        _audioSource.PlayDelayed(_initWait); //Play after init timer for slower player introduction
    }

    public void changeAudioClip(int clipIndex)
    {
        _audioSource.clip = _guideSteps[_clipIndex];
    }

    IEnumerator FixedWait()
    {
        float timer = Time.time + _initWait;

        while (Time.time < timer)
        {
            _isWaiting = true;
            yield return null;
        }

        _isWaiting = false;
        yield return null;
    }
}
