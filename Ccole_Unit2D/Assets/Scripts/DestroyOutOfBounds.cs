using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float TopofScene = 30.0f;
    private float BottomofScene = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > TopofScene)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < BottomofScene)
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }
}
