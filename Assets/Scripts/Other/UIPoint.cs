using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIPoint : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [HideInInspector] private int _score = 0;
    
    private void Update()
    {
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        _score = TriggerManager.Instance.triggerPot;
        scoreText.text = _score.ToString();
    }
}
