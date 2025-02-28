using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateIsaac : MonoBehaviour
{
    [SerializeField] Animator bodyAnim;

    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            bodyAnim.SetBool("Move Right", true);
        }
        else if (Input.GetAxisRaw("Vertical") != 0)
        {
            bodyAnim.SetBool("Move Up", true);
        }
        else
        {
            bodyAnim.SetBool("Move Right", false);
            bodyAnim.SetBool("Move Up", false);
        }
    }
}
