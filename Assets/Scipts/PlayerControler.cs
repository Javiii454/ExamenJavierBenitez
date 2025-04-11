using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float inputHorizontal;
    private float jumpPower = 10f;
    private float playerSpeed = 4.5f;
    private GroundSensor grundSensor;
    // Start is called before the first frame update
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        grundSensor = GetComponentInChildren<GroundSensor>();

    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(inputHorizontal > 0)
        {
        transform.rotation = Quaternion.Euler(0,0,0);
        }

        else if(inputHorizontal < 0)
        {
        transform.rotation = Quaternion.Euler(0,180,0);
        }

        if(Input.GetButtonDown("Jump") && grundSensor.isGrounded == true)

        {
            Jump();
        }
    }

      void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(playerSpeed * inputHorizontal, rigidBody.velocity.y);
    }

    void Jump()
    {
       rigidBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

    }
}

  
