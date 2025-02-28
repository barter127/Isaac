using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class HitRecoil : MonoBehaviour
{
    [SerializeField] float reduction;
    [SerializeField] float forceMultiplier;

    Rigidbody2D rb;

    // Forces.
    Vector2 contactPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tear")
        {
            // Get point of contact.
            ContactPoint2D contact = collision.contacts[0];
            contactPos = contact.normal;

            rb.AddForce(contactPos * forceMultiplier, ForceMode2D.Impulse);
        }

    }
}
