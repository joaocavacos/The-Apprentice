using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange;

    public float damage;

    public Animator playerAnim;
    public Transform attackPos;
    public LayerMask isEnemy;

    private float timePressed;
    bool isCharged = false;

	 void Start()
	{
        timePressed = 1f;
	}

	void Update()
    {
        Attack();
    }

	void OnDrawGizmosSelected() //Do this to check the range of the attack in a visual way
	{
        Gizmos.color = Color.white; 
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}

    public void Attack()
	{
        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Space)) //Charge attack
        {
            timePressed += Time.deltaTime;
        }

        if(Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Space)) //Release
		{
            isCharged = true;
		}

		if (isCharged)
		{
            playerAnim.SetTrigger("Attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemy); //creates invisible "raycast" circle that checks surroundings
            Debug.Log("Time pressed: "+ timePressed);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage * timePressed); //Do damage from how much you pressed
                isCharged = false;
                Debug.Log("Total damage: " + damage * timePressed);
            }
            timePressed = 1f;
        }
    }

}
