using UnityEngine;

public class GaperAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator headAnimator;
    [SerializeField] SpriteRenderer spr;

    [SerializeField] EnemyAStarMovement movement;

    void Update()
    {
        // Flip sprite renderer if nessecary.
        bool targetOnRight = movement.target.position.x > transform.position.x;
        spr.flipX = !targetOnRight;

        bool animateRight = Mathf.Abs(movement.target.position.x - transform.position.x) > Mathf.Abs(movement.target.position.y - transform.position.y);

        // Set body animation vars.
        animator.SetBool("Move Up", !animateRight);
        animator.SetBool("Move Right", animateRight);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Player enters eyes open range.
        if (collision.CompareTag("Player"))
        {
            headAnimator.SetTrigger("Open Eyes");
        }
    }
}
