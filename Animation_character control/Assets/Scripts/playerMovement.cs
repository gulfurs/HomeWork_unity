using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D myBody;
    private Animator myAnimation;
    [SerializeField] private int speed = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x !=0 || movement.y !=0){
            myAnimation.SetFloat("x", movement.x);
            myAnimation.SetFloat("y", movement.y);
            myAnimation.SetBool("isWalking", true);
        }else{
            myAnimation.SetBool("isWalking", false);
        }

    }

    private void FixedUpdate(){
        myBody.velocity = movement * speed;
    }

}
