using UnityEngine;

public class AnimateBody : MonoBehaviour
{
    PlayerMovement playerMov;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerMov = GetComponentInParent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMov.movement.y != 0)
        {
            anim.SetBool("Move Up", true);
            anim.SetBool("Move Right", false);
        }
        else if (playerMov.movement.x != 0)
        {
            anim.SetBool("Move Right", true);
            anim.SetBool("Move Up", false);
        }
        else
        {
            anim.SetBool("Move Right", false);
            anim.SetBool("Move Up", false);
        }

        if (playerMov.movement.x != 0)
        {
            CheckDirectionToFace(playerMov.movement.x > 0);
        }
    }

    void Turn()
    {
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        playerMov.isFacingRight = !playerMov.isFacingRight;
    }

    void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != playerMov.isFacingRight)
        {
            Turn();
        }
    }
}
