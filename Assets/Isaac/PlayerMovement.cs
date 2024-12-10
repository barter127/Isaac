using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement.
    [SerializeField] Rigidbody2D rb;
    public Vector3 movement;
    [SerializeField] float accelRate;
    [SerializeField] float maxSpeed;

    public bool isFacingRight = true;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        movement = movement.normalized;

        float xTarget = movement.x * maxSpeed;
        float xSpeedDif = xTarget - rb.linearVelocity.x;
        float xMovement = xSpeedDif * accelRate;

        float yTarget = movement.y * maxSpeed;
        float ySpeedDif = yTarget - rb.linearVelocity.y;
        float yMovement = ySpeedDif * accelRate;

        rb.AddForce(xMovement * Vector2.right);
        rb.AddForce(yMovement * Vector2.up);
    }
}
