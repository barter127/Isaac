using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    float rotationAngle = 0;

    [SerializeField] GameObject bullet;
    [SerializeField] float angleScale;
    [SerializeField] float fireRate;
    [SerializeField] float bulletsPerShot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Straight", 0f, fireRate);
        angleScale = 360 / bulletsPerShot;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spiral()
    {
        Vector3 bulletDir = Vector3.zero;

        // Loop for amount of shots.
        for (int i = 0; i <= bulletsPerShot - 1; i++)
        {
            // Get 
            float movementX = transform.position.x + Mathf.Sin(((rotationAngle + angleScale * i) * Mathf.PI) / 180);
            float movementY = transform.position.y + Mathf.Cos(((rotationAngle + angleScale * i) * Mathf.PI) / 180);

            Vector3 moveVector = new Vector3(movementX, movementY, 0);
            bulletDir = (moveVector - transform.position).normalized;

            GameObject spawnedBull = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBull.GetComponent<ProjectileMovement>().SetDirection(bulletDir);
        }

        // Update rotation angle.
        rotationAngle += 10f;
        if (rotationAngle >= 360)
        {
            rotationAngle = 0;
        }
    }   

    void Straight()
    {
        Vector3 bulletDir = Vector3.zero;

        for (int i = 0; i <= bulletsPerShot - 1; i++)
        {
            // Vector up unessecary but adds readability.
            bulletDir.x = Mathf.Cos(Vector2.up.x * rotationAngle) - Mathf.Sin(Vector2.up.y * rotationAngle);
            bulletDir.y = Mathf.Sin(Vector2.up.x * rotationAngle) + Mathf.Cos(Vector2.up.y * rotationAngle);
            bulletDir = bulletDir.normalized;

            GameObject spawnedBull = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBull.GetComponent<ProjectileMovement>().SetDirection(bulletDir);

            rotationAngle += angleScale;

            if (rotationAngle >= 360)
            {
                rotationAngle = 0;
            }

            Debug.Log(rotationAngle);
        }
    }
}
