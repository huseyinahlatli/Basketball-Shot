using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [HideInInspector] public int triggerPot = 0;
    [SerializeField] private EdgeCollider2D _edgeCollider;
    
    #region Singleton Class: Trigger Manager

    public static TriggerManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pot"))
        {
            triggerPot += 1;
            StartCoroutine(TriggerEnable());
        }
    }

    private IEnumerator TriggerEnable()
    {
        _edgeCollider.isTrigger = true;
        yield return new WaitForSeconds(.5f);
        _edgeCollider.isTrigger = false;
    }
    
    private IEnumerator ChangePosition() // disabled
    {
        yield return new WaitForSeconds(.25f);
        gameObject.transform.position = new Vector3(0f, -4.5f, 0f);
        gameObject.GetComponent<TrailRenderer>().enabled = true;
    }
}
