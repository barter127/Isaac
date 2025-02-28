using UnityEngine;
using System.Collections;

public class ChargeTowardPlayer : MonoBehaviour
{
    [SerializeField] float chargeForce;
    [SerializeField] float rateOfCharges;

    float chargeTimer;
    bool isCharging = false;

    Rigidbody2D rb;
    Transform playerTrans;
    Vector3 targetPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTrans = GameObject.Find("Isaac").transform;
    }

    void Update()
    {
        targetPos = playerTrans.position - transform.position;

        RaycastHit2D hit;

        if (Physics2D.Linecast(transform.position, targetPos))
            Debug.DrawRay(transform.position, targetPos, Color.red);
        
        else
            Debug.DrawRay(transform.position, targetPos, Color.green);

        if (chargeTimer <= 0)
        {
            if (Physics2D.Linecast(transform.position, targetPos) == false)
            { 
                Charge();
            }
        }
        else chargeTimer -= Time.deltaTime; 
    }

    void Charge()
    {
        chargeTimer = rateOfCharges;

        targetPos = playerTrans.position - transform.position;
        rb.AddForce(targetPos * chargeForce);
    }
}
