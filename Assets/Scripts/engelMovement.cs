using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engelMovement : MonoBehaviour
{
    public Transform enemyMove;
    private bool fight = true;
    public Rigidbody rB;
    public Vector3 kuvvet;
    void Start()
    {
        
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (fight)
        {
            transform.Rotate(-1f, -1f, -1f);
            rB.AddForce(kuvvet);
        }
        // gameObject.transform.position = enemyMove.transform.position + new Vector3(-3,9, 988);

    }
    private void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            fight = false;

        }


    }

}
