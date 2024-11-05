using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody EnemyRB;
    GameObject Player;
    public float Speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        EnemyRB = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -15)
        {
            Destroy(gameObject);
        }
        Vector3 SeekDirection = (Player.transform.position - transform.position).normalized;      
        EnemyRB.AddForce(SeekDirection * Speed * Time.deltaTime);

    }

}
