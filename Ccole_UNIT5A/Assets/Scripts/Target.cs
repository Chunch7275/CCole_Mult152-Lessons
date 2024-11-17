using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const float minforce = 10;
    private const float maxforce = 15;
    private const float mintorque = -10;
    private const float maxtorque = 10;
    private const float minxpos = -3;
    private const float maxxpos = 3;
    private const float yspawnpos = -2;

    private Rigidbody TargetRB;
    // Start is called before the first frame update
    void Start()
    {
        TargetRB = GetComponent<Rigidbody>();
        RandForce();
        RandTorque();
        RandSpawn();

    }

    void RandForce()
    {
        TargetRB.AddForce(Vector3.up * Random.Range(minforce, maxforce), ForceMode.Impulse);

    }

    void RandTorque()
    {
        TargetRB.AddTorque(Random.Range(mintorque, maxtorque), Random.Range(mintorque, maxtorque), Random.Range(mintorque, maxtorque), ForceMode.Impulse);

    }

    void RandSpawn()
    {
        transform.position = new Vector3(Random.Range(minxpos, maxxpos), yspawnpos);

    }
    // Update is called once per frame
    private void OnMouseDown() 
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}