using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private float _seconds = 1.5f;
    private AudioSource _audioSource;
    private bool _isEnteredHouse = false;
    private int _volumeChangeSteps = 10;
    private float _volumeDelta = 0.1f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            Debug.Log("INTRUDER!");
            
            if (_isEnteredHouse == false)
            {
                StartCoroutine(FadeIn());
            }
            else
            {
                StartCoroutine(FadeOut());
            }
        }
    }

    private IEnumerator FadeIn()
    {
        Debug.Log("Inside Fade In method");
        _isEnteredHouse = true;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
        var waitFor = new WaitForSeconds(_seconds);
        
        for (int i = 0; i < _volumeChangeSteps; i++)
        {
            _audioSource.volume += _volumeDelta;
            yield return waitFor;
        }
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("Inside fade out method");
        _isEnteredHouse = false;
        _audioSource = GetComponent<AudioSource>();
        var waitForSeconds = new WaitForSeconds(_seconds);
        
        for (int i = 0; i < _volumeChangeSteps; i++)
        {
            Debug.Log(i);
            _audioSource.volume -= _volumeDelta;
            yield return waitForSeconds;
        }
    }
}
