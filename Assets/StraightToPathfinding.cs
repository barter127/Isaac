using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class StraightToPathfinding : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;

    void Start()
    {
        GameObject playerObj = GameObject.Find("Isaac");
        player = playerObj.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Move at consistant rate.
        transform.position = Vector2.MoveTowards(transform.position ,player.position , speed * Time.fixedDeltaTime);
    }
}
