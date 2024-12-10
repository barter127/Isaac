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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTrans = GameObject.Find("Isaac").transform;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = playerTrans.position - transform.position;
        Debug.DrawRay(transform.position, targetPos, Color.red);

        if (Physics2D.Linecast(transform.position, targetPos))
        {
            Debug.DrawRay(transform.position, targetPos, Color.green);
            Debug.Log("blocked");
        }

        if (chargeTimer <= 0)
        {
            
            if (Physics2D.Linecast(transform.position, targetPos))
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
