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
    }
}
