using UnityEngine;

public class AnimateHead : MonoBehaviour
{
    PlayerMovement playerMov;
    IsaacShoot shoot;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playerMov = GetComponentInParent<PlayerMovement>();
        shoot = GetComponent<IsaacShoot>();
    }

    void Update()
    { 
        // Favour shooting.
        if (shoot.shootDir != Vector3.zero)
        {
            anim.SetBool("Is Shooting", true);
            anim.SetBool("IsFiring", shoot.isFiring);
            shoot.isFiring = false;

            anim.SetFloat("xShoot", shoot.shootDir.x);
            anim.SetFloat("yShoot", shoot.shootDir.y);
        }
        // Then favour y movement.
        else if (playerMov.movement.y != 0)
        {
            anim.SetFloat("yMove", playerMov.movement.y);
            anim.SetFloat("xMove", 0);
            anim.SetBool("Is Shooting", false);
        }
        else
        {
            anim.SetFloat("xMove", playerMov.movement.x);
            anim.SetFloat("yMove", 0);
            anim.SetBool("Is Shooting", false);

        }
    }
}
