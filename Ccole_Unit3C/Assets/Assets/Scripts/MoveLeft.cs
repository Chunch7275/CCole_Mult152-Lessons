using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed;
    private PlayerController controller;
    private float LeftBounds = -10;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if(transform.position.x < LeftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
