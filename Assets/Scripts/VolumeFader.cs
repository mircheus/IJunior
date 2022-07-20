using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class VolumeFader : MonoBehaviour
{
    [SerializeField] private float _seconds = 1f;
    [SerializeField] private AudioSource _audioSource;
    private Coroutine _alarmFader;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    
    public void TurnOnAlarm()
    { 
        if (_alarmFader != null)
        {
            Debug.Log("coroutine stopped in TurnOnSignal");
            StopCoroutine(_alarmFader);
        }
        
        _alarmFader = StartCoroutine(FadeVolumeTo(1));
    }

    public void TurnOffAlarm()
    {
        if (_alarmFader != null)
        {
            Debug.Log("coroutine stopped in TurnOffSignal");
            StopCoroutine(_alarmFader);
        }
        
        _alarmFader  = StartCoroutine(FadeVolumeTo(0));
    }

    private IEnumerator FadeVolumeTo(float targetVolume)
    {
        var waitFor = new WaitForSeconds(_seconds);
        float volumeDelta = 0.1f;
        
        while (_audioSource.volume != targetVolume)
        { 
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, volumeDelta);
            yield return waitFor;
        }
    }
    
}
