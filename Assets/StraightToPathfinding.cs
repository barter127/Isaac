using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightToPathfinding : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed;
   
    void Start()
    {
        GameObject playerObj = GameObject.Find("Isaac");
        player = playerObj.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position ,player.position , speed * Time.fixedDeltaTime);
    }
}
