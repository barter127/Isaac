using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] SpriteRenderer spr;
    [SerializeField] SpriteRenderer sprHead;
    [SerializeField] GameObject bloodSplatterFX;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tear"))
        {
            float damage = collision.gameObject.GetComponent<ProjectileMovement>().damage;
            health -= damage;

            if (spr != null)
            {
                VFXManager.FlashRed(spr, 0.1f);
                VFXManager.FlashRed(sprHead, 0.1f);
            }
        }

        if (health <= 0)
        {
            Instantiate(bloodSplatterFX, transform.position, Quaternion.identity);
           Destroy(gameObject);
        }
    }
}
