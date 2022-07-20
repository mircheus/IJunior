using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VolumeFader : MonoBehaviour
{
    [SerializeField] private float _seconds = 1f;
    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }

    public void TurnOnSignal()
    {
        StartCoroutine(FadeVolumeTo(1));
    }

    public void TurnOffSignal()
    {
        StartCoroutine(FadeVolumeTo(0));
    }

    private IEnumerator FadeVolumeTo(float target)
    {
        var waitFor = new WaitForSeconds(_seconds);
        float volumeDelta = 0.1f;
        
        while (_audioSource.volume != target)
        { 
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, volumeDelta);
            yield return waitFor;
        }
    }
    
}
