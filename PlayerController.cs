using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int walkSpeed;
    public int runSpeed;
    int speed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundDistance;
    bool isGrounded;
    public LayerMask groundLayer;

    public Rigidbody rb;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
        } else
        {
            speed = walkSpeed;
        }

        Move();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + transform.TransformDirection(direction * speed * Time.deltaTime));
    }

    void Jump()
    {
        rb.velocity = new Vector3(0f, rb.velocity.y + jumpSpeed, 0f);
    }
}
