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
            _audioSource = GetComponent<AudioSource>();
            
            Debug.Log("INTRUDER!");
            
            if (_isEnteredHouse == false)
            {
                _audioSource.Play();
                StartCoroutine(Fader(_volumeDelta));
            }
            else
            {
                StartCoroutine(Fader(_volumeDelta * -1f));
            }
        }
    }

    private IEnumerator Fader(float volumeDelta)
    {
        Debug.Log("Inside Fader method");
        _isEnteredHouse = true;
        var waitFor = new WaitForSeconds(_seconds);
        
        for (int i = 0; i < _volumeChangeSteps; i++)
        {
            _audioSource.volume += volumeDelta;
            yield return waitFor;
        }
    }
}
