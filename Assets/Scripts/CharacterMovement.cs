using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rigidBody;
    public Transform groundCheckTransform;

    public float speed = 0.1f;
    public float jumpingThrust = 7.0f;
    private float nextJumpTime;
    public float jumpDuration = 0.1f;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(groundCheckTransform.position , Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 0.1f))
            return true;
        else
            return false;
    }

    void FixedUpdate() 
    {
        // if(Input.GetKey("w")) {
        //     gameObject.transform.Translate(Vector3.forward*speed);
        // }
        // if(Input.GetKey("a")) {
        //     gameObject.transform.Translate(Vector3.left*speed);
        // }
        // if(Input.GetKey("d")) {
        //     gameObject.transform.Translate(Vector3.right*speed);
        // }
        // if(Input.GetKey("s")) {
        //     gameObject.transform.Translate(Vector3.back*speed);
        // }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;
        velocity += x*transform.right;
        velocity += z*transform.forward;
        velocity *= speed;

        velocity.y = rigidBody.velocity.y;
        rigidBody.velocity = velocity;

        if(Input.GetKey("space") && IsGrounded() && Time.timeSinceLevelLoad >= nextJumpTime) {
            rigidBody.AddForce(Vector3.up * jumpingThrust, ForceMode.Impulse);
            nextJumpTime = Time.timeSinceLevelLoad + jumpDuration;
        }
    }
}
