using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    private float xInput;
    private float yInput;

    [SerializeField] float speed;


    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(xInput, yInput).normalized;
        rb.velocity = (moveDir * speed);
    }
}
