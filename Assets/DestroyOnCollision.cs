using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    Collider2D col;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        Destroy(gameObject);
    }
}
