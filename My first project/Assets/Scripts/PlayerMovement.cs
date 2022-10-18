using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]float mSpeed = 5f;
    [SerializeField]float jSpeed = 6f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump")){
            rb.velocity = new Vector3(rb.velocity.x, jSpeed, rb.velocity.z);
        }

        rb.velocity = new Vector3(horizontalInput * mSpeed, rb.velocity.y ,verticalInput * mSpeed);

        
    }
}
