using UnityEngine;
using UnityEngine.AI;

public class IncreaseGaperSpeed : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float awokenSpeed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            agent.speed = awokenSpeed;
            agent.acceleration = awokenSpeed * 100;
        }
    }
}
