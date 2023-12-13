using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0.1f;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    void FixedUpdate() 
    {
        if(Input.GetKey("w")) {
            gameObject.transform.Translate(Vector3.forward*speed);
        }
        if(Input.GetKey("a")) {
            gameObject.transform.Translate(Vector3.left*speed);
        }
        if(Input.GetKey("d")) {
            gameObject.transform.Translate(Vector3.right*speed);
        }
        if(Input.GetKey("s")) {
            gameObject.transform.Translate(Vector3.back*speed);
        }
        if(Input.GetKey("space")) {
            rb.AddForce(Vector3.up * 20.0f);
        }
    }
}
