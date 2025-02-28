using UnityEngine;

public class BulletEffects : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float angleScale;
    [SerializeField] float fireRate;
    [SerializeField] float bulletsPerShot;
    [SerializeField] int offsetIncrease;

    float rotationAngle = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("Spiral", 0f, fireRate);
        angleScale = 360 / bulletsPerShot;
    }

    void Update()
    {
        angleScale = 360 / bulletsPerShot;
    }

    void Spiral()
    {
        Vector3 bulletDir = Vector3.zero;

        // Loop for amount of shots.
        for (int i = 0; i <= bulletsPerShot - 1; i++)
        {
            // Get bullet move dir.
            float degrees = rotationAngle + angleScale * i;
            float bulletDirX = Mathf.Sin((degrees * Mathf.PI) / 180);
            float bulltDirY = Mathf.Cos((degrees * Mathf.PI) / 180);

            bulletDir = new Vector3(bulletDirX, bulltDirY, 0);

            // Spawn bullet and set direction.
            GameObject spawnedBull = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBull.GetComponent<ProjectileMovement>().SetDirection(bulletDir);
        }

        // Update rotation angle.
        rotationAngle += offsetIncrease;
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
            float shotAngle = angleScale * i;

            // Calculate the bullet's direction using trigonometry
            bulletDir.x = Mathf.Cos(shotAngle * Mathf.PI / 180);
            bulletDir.y = Mathf.Sin(shotAngle * Mathf.PI / 180);

            GameObject spawnedBull = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBull.GetComponent<ProjectileMovement>().SetDirection(bulletDir);
        }
    }    

    void Scattershot()
    {
        Vector3 bulletDir = Vector3.zero;

        for (int i = 0; i <= bulletsPerShot - 1; i++)
        {
            float rotationAngle = angleScale * i;
            rotationAngle = Mathf.Deg2Rad * rotationAngle;

            // Calculate the bullet's direction using trigonometry
            // Vector up unessecary but adds readability.
            bulletDir.x = Mathf.Cos(Vector2.up.x * rotationAngle) - Mathf.Sin(Vector2.up.y * rotationAngle);
            bulletDir.y = Mathf.Sin(Vector2.up.x * rotationAngle) + Mathf.Cos(Vector2.up.y * rotationAngle);
            bulletDir = bulletDir.normalized;


            GameObject spawnedBull = Instantiate(bullet, transform.position, transform.rotation);
            spawnedBull.GetComponent<ProjectileMovement>().SetDirection(bulletDir);
        }
    }
}
