using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        transform.position = Vector2.MoveTowards(transform.position ,player.position , speed * Time.fixedDeltaTime);
    }
}
