using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float dashSpeed;
    public float startDashTime;
    private float dashTime;

    private int direction;

    private Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		dashTime = startDashTime;
	}

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;
        Debug.Log(movement);
        
        
    }

	void FixedUpdate()
	{
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
        DashMovement();
	}

	void DashMovement()
	{
		if (direction == 0)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (movement.y > 0  && movement.x == 0) direction = 1; //Up
				else if (movement.y < 0 && movement.x == 0) direction = 2; //Down
				else if (movement.y == 0 && movement.x > 0) direction = 3; //Right
				else if (movement.y == 0 && movement.x < 0) direction = 4; //Left
				
			}
		}
		else
		{
			if (dashTime <= 0)
			{
				direction = 0;
				dashTime = startDashTime;
				rb.velocity = Vector2.zero;
			}
			else
			{
				dashTime -= Time.deltaTime;
				switch (direction)
				{
					case 1:
						rb.velocity = Vector2.up * dashSpeed;
						break;
					case 2:
						rb.velocity = Vector2.down * dashSpeed;
						break;
					case 3:
						rb.velocity = Vector2.right * dashSpeed;
						break;
					case 4:
						rb.velocity = Vector2.left * dashSpeed;
						break;
				}
			}
		}
	}
}
