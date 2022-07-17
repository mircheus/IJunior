using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform[] _points;
    private int _currentPoint;

    void Start()
    {
        _points = new Transform[_path.childCount];
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }


    void Update()
    {
        Transform target = _points[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        
        if (transform.position == target.position)
        {
            // Debug.Log("REACHED");
            _currentPoint++;
            
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
        
        switch (_currentPoint)
        {
            case 0:
                _animator.Play("Thief_walk");
                break;
            
            case 1:
                _animator.Play("Thief_crouch");
                break;
            
            case 2:
                _animator.Play("Thief_run");
                _speed = 4;
                _spriteRenderer.flipX = true;
                break;            
            
            case 3:
                _animator.Play("Thief_jump");
                break;
        }
    }
}
