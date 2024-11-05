using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    GameObject Focal;
    Renderer rendererP;
    public float speed = 10.0f;
    public float PowerUpSpeed = 15.0f;
    public GameObject PowerUpIND;

    bool HasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        rendererP = GetComponent<Renderer>();
        Focal = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(Focal.transform.forward * magnitude, ForceMode.Impulse);

        rendererP.material.color = new Color(1.0f - Math.Abs(forwardInput),1.0f,1.0f - Math.Abs(forwardInput));

        PowerUpIND.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            HasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            PowerUpIND.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision  collision)
    {
      if (HasPowerUp && collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Collission with Enemy");
            Rigidbody rbenemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 AwayDir = collision.gameObject.transform.position - transform.position;
            rbenemy.AddForce(AwayDir * PowerUpSpeed, ForceMode.Impulse);
        }
    }
     IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(8);
        HasPowerUp = false;
        PowerUpIND.SetActive(false);

    }
}
