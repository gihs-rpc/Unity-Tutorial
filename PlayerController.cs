using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int walkSpeed;
    public int runSpeed;
    int speed;
    public Rigidbody rb;
    Vector3 direction;

	// Use this for initialization
	void Start () {
        speed = walkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
        } else
        {
            speed = walkSpeed;
        }
        Move();
	}

    void Move()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
    }
}
