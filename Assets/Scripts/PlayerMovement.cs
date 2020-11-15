using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float dashSpeed;
    public float startDashTime;
    public float manaUsage;
    private float dashTime;

    private int direction;

    private Rigidbody2D rb;
    public Animator animator;
    private ManaSystem _manaSystem;

    Vector2 movement;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		dashTime = startDashTime;
		_manaSystem = GetComponent<ManaSystem>();
	}

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized; //Normalized for diagonal run
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); //SqrMagnitude for optimization


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
			if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button5)) //shift or RB
			{
				if (movement.y > 0  && movement.x == 0) direction = 1; //Up
				else if (movement.y < 0 && movement.x == 0) direction = 2; //Down
				else if (movement.y == 0 && movement.x > 0) direction = 3; //Right
				else if (movement.y == 0 && movement.x < 0) direction = 4; //Left
				
			}
		}
		else
		{
			if (dashTime <= 0) //If not dashing
			{
				direction = 0;
				dashTime = startDashTime;
				rb.velocity = Vector2.zero;
			}
			else
			{
				dashTime -= Time.deltaTime;
				switch (direction) //Directions that can dash
				{
					case 1:
						rb.velocity = Vector2.up * dashSpeed; //Up
						break;
					case 2:
						rb.velocity = Vector2.down * dashSpeed; //Down
						break;
					case 3:
						rb.velocity = Vector2.right * dashSpeed; //Right
						break;
					case 4:
						rb.velocity = Vector2.left * dashSpeed; //Left
						break;
				}
			}
			_manaSystem.UseAbility(manaUsage); // Not working , decreases a lot more
		}
	}
}
