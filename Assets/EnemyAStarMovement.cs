using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAStarMovement : MonoBehaviour
{
    public Transform target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float damageForce;

    bool isMoving = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(PauseMovement(0.1f));

        if (collision.gameObject.CompareTag("Tear"))
        {
            Vector3 blowbackForce = collision.gameObject.GetComponent<ProjectileMovement>().bulletDir;
            rb.AddForce(blowbackForce * damageForce, ForceMode2D.Impulse);
        }
    }

    IEnumerator PauseMovement(float seconds)
    {
        agent.isStopped = true;

        yield return new WaitForSeconds(seconds);

        agent.isStopped = false;
    }
}
