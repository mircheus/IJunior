using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationSetter : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _reached.Invoke();
        }
    }
}
