using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GuideEvents : MonoBehaviour {

    private UnityAction someListener;
    [SerializeField] AudioClip[] _guideSteps = new AudioClip[7];
    [SerializeField] private float _initWait = 3f;
    private AudioSource _audioSource;
    private int _clipIndex = 0;
    private bool _isWaiting;

    public int ClipIndex
    {
        get { return _clipIndex; }
        set { _clipIndex = value; }
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        changeAudioClip(_clipIndex); //Start with first guide clip
        _audioSource.PlayDelayed(_initWait); //Play after init timer for slower player introduction
        StartCoroutine("PlayNextAudioClipAfterWaitForCurrent");
    }

    void OnEnable()
    {
        EventManager.StartListening("nextClip", changeAudioClip);
        EventManager.StartListening("playClip", playAudioClip);
    }

    void OnDisable()
    {
        EventManager.StopListening("nextClip", changeAudioClip);
        EventManager.StopListening("playClip", playAudioClip);
    }

    public void changeAudioClip()
    {
        _clipIndex += 1;
        _audioSource.clip = _guideSteps[_clipIndex];
    }

    public void changeAudioClip(int clipIndex) //overload method for specific clip number
    {
        _audioSource.clip = _guideSteps[clipIndex];
    }

    public void playAudioClip()
    {
        _audioSource.Play();
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
    } //Coroutine for initial wait

    IEnumerator PlayNextAudioClipAfterWaitForCurrent()
    {
        while (_audioSource.isPlaying)
        {
            yield return null;
        }
        changeAudioClip();
        playAudioClip();
        yield return null;
    } //Play next audio clip when current is finished
}