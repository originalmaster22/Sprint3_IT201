using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce = 750;
    public float velocity;
    public bool isGrounded;
    private float speed = 10.0f;
    private float rotationSpeed = 720f;
    public static float xMovement;
    public static float zMovement;
    Vector3 moveDirection;
    public Transform orientation;
    public int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGround();
        playerInput();
        movePlayer();
        
    }
    //Code feature 7
    void CheckGround()
    {
	    RaycastHit hit;
	    float distance = 1f;
	    Vector3 dir = new Vector3(0, -1, 0);

	    if(Physics.Raycast(transform.position, dir, out hit, distance))
	    {
		    isGrounded = true;
	    }
	    else
	    {
		    isGrounded = false;
	    }
    }

    void playerInput() {
        //gets keyboard movement
        xMovement = Input.GetAxisRaw("Horizontal");
        zMovement = Input.GetAxisRaw("Vertical");
    }

    void movePlayer() {
        moveDirection = orientation.forward * zMovement + orientation.right * xMovement;
        
        moveDirection.Normalize();
        if(Input.GetKey(KeyCode.LeftShift) && isGrounded) {
            transform.Translate(moveDirection * Time.deltaTime * speed * 1.5f, Space.World);
        } else {
            transform.Translate(moveDirection * Time.deltaTime * speed, Space.World);
        }
        if(moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            
        }

        
    }
}
