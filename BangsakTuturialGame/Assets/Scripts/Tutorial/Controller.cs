using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 2.0f;
    public float gravity = -25.0f;
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    private float jumpheight = 1f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (true) {
            if (characterController.isGrounded) {
                velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                velocity = transform.TransformDirection(velocity);

                if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.W)){
                    velocity *= 2.5f;
                }     
                
                else if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.W)){
                    velocity *= 2.5f;
                }

                else if(Input.GetKeyDown (KeyCode.Space) && Input.GetKey (KeyCode.W) && isGrounded){
                    velocity *= speed * 2;
                    velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                } 

                else if(Input.GetKeyDown (KeyCode.Space) && Input.GetKey (KeyCode.S) && isGrounded){
                    velocity *= 3f;
                    velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                }
                else if(Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)){
                    Debug.Log("Pressed Shift");
                    velocity *= 8f;
                } 

                else if(Input.GetKey (KeyCode.A) && Input.GetKey (KeyCode.S)){
                    velocity *= 1.5f;
                }
                else if(Input.GetKey (KeyCode.D) && Input.GetKey (KeyCode.S)){
                    velocity *= 1.5f;
                }
                
                else if(Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.S)){
                    velocity *= 0f;
                }

                else if(Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.Space)){
                    velocity *= speed * 3;
                }
                //Basic Movements
                else if(Input.GetKey (KeyCode.W)){
                    velocity *= 5f;
                }
                else if(Input.GetKey (KeyCode.A)){

                    velocity *= speed;

                }
                else if(Input.GetKey (KeyCode.D)){

                    velocity *= speed;

                }
                else if(Input.GetKey (KeyCode.S)){
                    velocity *= 2f;
                } 
                else if(Input.GetKeyDown (KeyCode.Space) && isGrounded){
                    velocity *= speed;
                    velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                } 
                else if(Input.GetKey (KeyCode.S)){
                    velocity *= 1f;
                } 
                
            }
            
        }   
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }
}