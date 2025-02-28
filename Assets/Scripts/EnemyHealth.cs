using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tear")
        {
            float damage = collision.gameObject.GetComponent<ProjectileMovement>().damage;
            health -= damage;
        }

        if (health <= 0)
        {
           Destroy(gameObject);
        }
    }
}
