using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    float timeAttack; 
    public float startTimeAttack; //time between attacks
    public float attackRange;

    public int damage;

    public Animator playerAnim;
    public Transform attackPos;
    public LayerMask isEnemy;


	void Update()
    {
            if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Space)) //If pressed B or space
            {
                Debug.Log("Attack launched");
                playerAnim.SetTrigger("Attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemy); //creates invisible "raycast" circle that checks surrondings

				for (int i = 0; i < enemiesToDamage.Length; i++)
				{
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
				}
            }    
    }

	void OnDrawGizmosSelected() //Do this to check the range of the attack in a visual way
	{
        Gizmos.color = Color.white; 
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}
}
