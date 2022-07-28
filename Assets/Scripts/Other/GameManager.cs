using System;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float pushForce = 4f;
    private Camera _camera;
    private bool _isDragging = false;
    
    public BallController ballController;
    public Trajectory trajectory;
    
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _direction;
    private Vector2 _force;
    private float _distance;
    
    #region Singleton Class: GameManager

    public static GameManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion

    private void Start()
    {
        _camera = Camera.main;
        ballController.DesactivateRigidbody();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            OnDragEnd();
        }

        if (_isDragging)
            OnDrag();
    }



    private void OnDragStart()
    {
        ballController.DesactivateRigidbody();
        _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    } 

    private void OnDrag()
    {
        _endPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * (_distance * pushForce);
        
        Debug.DrawLine(_startPoint, _endPoint);
        trajectory.UpdateDots(ballController.pos, _force);
    }
    
    private void OnDragEnd()
    {
        ballController.ActivateRigidbody();
        ballController.Push(_force);

        trajectory.Hide();
    }
}

