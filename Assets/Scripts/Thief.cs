using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;
    [SerializeField] private int _runSpeed = 5;

    private int _walk = Animator.StringToHash("walk");
    private int _crouch = Animator.StringToHash("crouch");
    private int _run = Animator.StringToHash("run");
    private int _jump = Animator.StringToHash("jump");
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
            _currentPoint++;
            
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
    
    public void SwitchToCrouch()
    {
        _animator.SetTrigger(_crouch);
        _animator.ResetTrigger(_jump);
    }    
    
    public void SwitchToRun()
    {
        _spriteRenderer.flipX = true;
        _animator.SetTrigger(_run);
        _speed = _runSpeed;
    }    
    
    public void SwitchToJump()
    {
        _animator.SetTrigger(_jump);
    }    
    
    public void SwitchToWalk()
    {
        _spriteRenderer.flipX = false;
        _animator.ResetTrigger(_crouch);
        _animator.SetTrigger(_walk);
    }
}
