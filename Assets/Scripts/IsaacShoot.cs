using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacShoot : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    [HideInInspector] public Vector3 shootDir;
    KeyCode lastInput;

    [SerializeField] GameObject bullet;

    [SerializeField] float shootTimerLength;
    float shootTimer;

    [Header ("Eyes")]
    [SerializeField] GameObject leftEye;
    [SerializeField] GameObject rightEye;
    public bool usingRightEye { get; private set; }

    public bool isFiring;

    [Header("Tear Momentum")]
    // Multiplier for bullet momentum.
    [SerializeField] float momentumPos;
    [SerializeField] float momentumNeg;

    private void Start()
    {
        usingRightEye = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }

        shootDir = Vector3.zero;

        // 
        if (Input.GetKey(KeyCode.LeftArrow)) shootDir.x = -1;
        if (Input.GetKey(KeyCode.RightArrow)) shootDir.x = 1;
        if (Input.GetKey(KeyCode.DownArrow)) shootDir.y = -1;
        if (Input.GetKey(KeyCode.UpArrow)) shootDir.y = 1;

        // Favor the most recent input for several key presses.
        if (Input.GetKey(lastInput))
        {
            if (lastInput == KeyCode.LeftArrow) shootDir.x = -1;
            if (lastInput == KeyCode.RightArrow) shootDir.x = 1;
            if (lastInput == KeyCode.DownArrow) shootDir.y = -1;
            if (lastInput == KeyCode.UpArrow) shootDir.y = 1;
        }

        // Update lastInput.
        if (Input.GetKeyDown(KeyCode.LeftArrow)) lastInput = KeyCode.LeftArrow;
        if (Input.GetKeyDown(KeyCode.RightArrow)) lastInput = KeyCode.RightArrow;
        if (Input.GetKeyDown(KeyCode.DownArrow)) lastInput = KeyCode.DownArrow;
        if (Input.GetKeyDown(KeyCode.UpArrow)) lastInput = KeyCode.UpArrow;

        // Favour Y axis.
        if (shootDir.y != 0)
        {
            shootDir.x = 0;
        }

        if (shootDir != Vector3.zero)
        {
            Shoot();
        }
    }
    
    void Shoot()
    {
        if (shootTimer <= 0)
        {
            isFiring = true;

            // Determine eye to shoot from.
            Vector2 tearSpawnPos = usingRightEye ? rightEye.transform.position : leftEye.transform.position;

            // Spawn tear.
            GameObject spawnedBullet = Instantiate(bullet, tearSpawnPos, Quaternion.identity);
            shootTimer = shootTimerLength;

            // Set projectile properties
            ProjectileMovement projMovement = spawnedBullet.GetComponent<ProjectileMovement>();

            shootDir = shootDir.normalized;

            //// Increase speed when moving with. Limit speed when moving against.
            float dirMultiplier = shootDir == playerMovement.movement ? momentumPos : momentumNeg;
            shootDir.x += playerMovement.movement.x * dirMultiplier;
            shootDir.y += playerMovement.movement.y * dirMultiplier;

            projMovement.SetDirection(shootDir);

            // Set bullet sort order.
            int sortOrder = usingRightEye ? 2 : 0;
            projMovement.SetSortingLayer(sortOrder);

            // Switch shooting eye.
            usingRightEye = !usingRightEye;
        }
    }
}
