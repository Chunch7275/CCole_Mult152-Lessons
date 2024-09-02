using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 15.0f;
    private float turnspeed = 15.0f;

    private float horizontalinput;
    private float verticalinput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
        Debug.Log(Time.deltaTime);

        //Forward/Back
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
      
        //Left/right
        transform.Rotate(Vector3.up, Time.deltaTime * turnspeed * horizontalinput);


    }
}
