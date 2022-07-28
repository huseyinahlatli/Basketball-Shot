using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotMovementY : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private int _moveState = 1;

    private void FixedUpdate()
    {
        if (_moveState == 1)
            UpMovement();
        
        if (_moveState == 2)
            DownMovement();
    }

    private void UpMovement()
    {
        if(transform.position.y < 2f)
            transform.Translate(Vector2.up * (moveSpeed * Time.deltaTime));
        else
            _moveState = 2;
    }

    private void DownMovement()
    {
        if(transform.position.y > 1f)
            transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));
        else
            _moveState = 1;
    }
}
