using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float forwardSpeed = 10f;  
    public float strafeSpeed = 30f;    
    public float rotationSpeed = 100f; 

    private Rigidbody rb;

    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveForward();
        HandleStrafing();
    }

    
    private void MoveForward()
    {
        // Move the box forward along the z-axis
        Vector3 forwardMovement = transform.forward * forwardSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMovement);
    }

  
    private void HandleStrafing()
    {
        
        float strafeInput = Input.GetAxis("Horizontal"); // This is the A/D or Left/Right arrow keys

        Vector3 strafeMovement = transform.right * strafeInput * strafeSpeed * Time.deltaTime;

        
        rb.MovePosition(rb.position + strafeMovement);
    }
}
