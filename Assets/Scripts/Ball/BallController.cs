using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BallController : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D> ();
        col = GetComponent<CircleCollider2D> ();
    }

    public void Push (Vector2 force)
    {
        rb.AddForce (force, ForceMode2D.Impulse);
    }

    public void ActivateRigidbody()
    {
        rb.isKinematic = false;
    }

    public void DesactivateRigidbody()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}
