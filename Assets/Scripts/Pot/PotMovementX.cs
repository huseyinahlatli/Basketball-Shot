using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary { public static float xMin, xMax; }
public class PotMovementX : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [HideInInspector] private Vector2 currentPosition;
    private int _moveState = 1;
    private void Start()
    {
        currentPosition = transform.position; 
    }

    private void FixedUpdate()
    {
        if (_moveState == 1)
            RightMovement();
        
        if (_moveState == 2)
            LeftMovement();
    }

    private void RightMovement()
    {
        if(transform.position.x < 2.1f)
            transform.Translate(Vector2.right * (moveSpeed * Time.deltaTime));
        else
            _moveState = 2;
    }

    private void LeftMovement()
    {
        if(transform.position.x > -2.1f)
            transform.Translate(Vector2.left * (moveSpeed * Time.deltaTime));
        else
            _moveState = 1;
    }
}
