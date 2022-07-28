using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField] private int dotsNumber;
    [SerializeField] private float dotSpacing;
    [SerializeField] private GameObject dotsParent;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] [Range (0.01f, 0.3f)] float dotMinScale;
    [SerializeField] [Range (0.3f, 1f)] float dotMaxScale;

    private Transform[] _dotsList;
    private Vector2 _position;
    private float _timeStamp;

    private void Start()
    {
        Hide();
        PrepareDots ();
    }

    private void PrepareDots()
    {
        _dotsList = new Transform[dotsNumber];
        for (int i = 0; i < dotsNumber; i++)
        {
            _dotsList[i] = Instantiate(dotPrefab, null).transform;
            _dotsList[i].parent = dotsParent.transform;
        }
    }
    
    public void UpdateDots(Vector3 ballPosition, Vector2 forceApplied)
    {
        _timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
             _position.x = (ballPosition.x + forceApplied.x * _timeStamp);
             _position.y = (ballPosition.y + forceApplied.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;

             _dotsList[i].position = _position;
             _timeStamp += dotSpacing;
        }
    }



    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
