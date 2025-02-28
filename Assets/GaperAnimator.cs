using UnityEngine;

public class GaperAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spr;

    [SerializeField] EnemyAStarMovement movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
