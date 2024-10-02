using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rbPlayer;
    public float GravityModifier;
    public float JumpForce;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        bool spaceDown = Input.GetKeyDown(KeyCode.Space);
        if (spaceDown && onGround)
        {
            rbPlayer.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            onGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
    }
}
