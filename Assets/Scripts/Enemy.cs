using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2.0f;
    private Rigidbody ennemyRb;
    private GameObject player;

    

    void Start()
    {
        ennemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - this.transform.position).normalized;
        this.ennemyRb.AddForce(lookDirection * speed);

        if(this.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
