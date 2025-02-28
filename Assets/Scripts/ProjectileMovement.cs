using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] SpriteRenderer spr;
    [SerializeField] GameObject splashFx;

    [Header("Properties")]
    public Vector3 bulletDir { get; private set; }
    [SerializeField] float shotSpeed;
    public float damage;

    float bulletTimer;
    [SerializeField] float bulletTimerLength;

    private void Start()
    {
        // Increase bullet lifespan
        bulletTimer = bulletTimerLength; //* (1 + dirMultiplier);
    }

    private void Update()
    {
        if (bulletTimer < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            bulletTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.position += bulletDir * shotSpeed * Time.fixedDeltaTime;
    }

    // Sets direction of bullet
    public void SetDirection(Vector3 newBulletDir)
    {
        bulletDir = newBulletDir * shotSpeed;
    }

    // Sets direction of bullet
    public void SetDirection(Vector2 newBulletDir)
    {

        bulletDir = new Vector3(newBulletDir.x, newBulletDir.y, 0) * shotSpeed;
    }

    // Sets sortning layer.
    public void SetSortingLayer(int orderInLayer)
    {
        spr.sortingOrder = orderInLayer;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Instantiate(splashFx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
