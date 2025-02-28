using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacShoot : MonoBehaviour
{
    public Vector3 shootDir;
    KeyCode lastInput;

    [SerializeField] GameObject bullet;

    [SerializeField] float shootTimerLength;
    float shootTimer;

    [SerializeField] GameObject leftEye;
    [SerializeField] GameObject rightEye;
    public bool usingRightEye { get; private set; }

    public bool isFiring;

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
            // Switch shooting eye.
            Vector2 tearSpawnPos = usingRightEye ? leftEye.transform.position : rightEye.transform.position;
            usingRightEye = !usingRightEye;

            isFiring = true;

            Instantiate(bullet, tearSpawnPos, Quaternion.identity);
            shootTimer = shootTimerLength;
        }
    }
}
