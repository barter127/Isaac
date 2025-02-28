using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DipAnimator : MonoBehaviour
{
    DipMovement move;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<DipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (move.startCharge)
        {
            move.startCharge = false;

            anim.SetTrigger("StartCharge");
        }
    }
}
