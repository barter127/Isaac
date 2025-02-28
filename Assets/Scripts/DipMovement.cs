using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class DipMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool startCharge; // For animator.
    bool isFacingRight;

    [SerializeField, Range(0, 10)] float minDistance;
    [SerializeField, Range(0, 10)] float maxDistance;

    // Time between attacks;
    [SerializeField, Range(0, 10)] float minTime; //Arbitrary large value. 
    [SerializeField, Range(0, 10)] float maxTime; //Arbitrary large value. 

    // Randomised values.
    Vector2 movementDir;
    float nextMovement;

    private void Start()
    {
        isFacingRight = true;

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (nextMovement < 0) 
        {
            startCharge = true;

            // Randomise timer.
            nextMovement = Random.Range(minTime, maxTime);

            // Randomise movementDir.
            movementDir.x = Random.Range(-maxDistance, maxDistance);
            movementDir.y = Random.Range(-maxDistance, maxDistance);

            movementDir.x = ClampDirection(movementDir.x);
            movementDir.y = ClampDirection(movementDir.y);

            CheckDirectionToFace(movementDir.x > 0);
            rb.AddForce(movementDir, ForceMode2D.Impulse);
        }
        else nextMovement -= Time.deltaTime;
    }
    
    float ClampDirection(float distance)
    {
        if (distance > 0)
        {
            return Mathf.Clamp(distance, minDistance, maxDistance);
        }
        else
        {
            return Mathf.Clamp(distance, -maxDistance, -minDistance);
        }
    }

    void Turn()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        isFacingRight = !isFacingRight;
    }

    void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != isFacingRight)
        {
            Turn();
        }
    }
}
