using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _entered;
    [SerializeField] private UnityEvent _exited;
    
    private bool _isEnteredHouse = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            if (_isEnteredHouse == false)
            {
                Debug.Log("INTRUDER!");
                _isEnteredHouse = true;
                _entered.Invoke();
            }
            else
            {
                Debug.Log("nontruder!");
                _isEnteredHouse = false;
                _exited.Invoke();
            }
        }
    }
}
