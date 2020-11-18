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
    public LayerMask isBoss;

    public AudioSource damageSound;
    public AudioSource swordSwing;

    public ParticleSystem chargeParticle;

    private float timePressed;
    bool isCharged = false;

	 void Start()
	{
        timePressed = 1f;
	}

	void Update()
    {
        AttackEnemies();
        AttackBoss();
    }

	void OnDrawGizmos() //Do this to check the range of the attack in a visual way
	{
        Gizmos.color = Color.white; 
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
	}

    public void AttackEnemies()
	{
        isCharged = false;

        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Space)) //Charge attack
        {

            swordSwing.Play();
            timePressed += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Space)) //Charge attack
        {

            chargeParticle.Play(true);
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Space)) //Release
		{
            isCharged = true;
            chargeParticle.Stop(true);
        }

		if (isCharged)
		{

            playerAnim.SetTrigger("Attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemy); //creates invisible "raycast" circle that checks surroundings
            Debug.Log("Time pressed: "+ timePressed);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamageEnemy(damage * timePressed); //Do damage from how much you pressed
                damageSound.Play();
                isCharged = false;
                Debug.Log("Total damage: " + damage * timePressed);
            }
            timePressed = 1f;
        }
    }

    public void AttackBoss()
    {
        isCharged = false;

        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Space)) //Charge attack
        {
            timePressed += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Joystick1Button1) || Input.GetKeyUp(KeyCode.Space)) //Release
        {
            isCharged = true;
        }
       

        if (isCharged)
        {
            playerAnim.SetTrigger("Attack");
            Collider2D[] colInfo = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isBoss); //creates invisible "raycast" circle that checks surroundings
            Debug.Log("Time pressed: " + timePressed);

            for (int i = 0; i < colInfo.Length; i++)
            {
                colInfo[i].GetComponent<BossHealth>().TakeDamageBoss(damage * timePressed); //Do damage from how much you pressed
                damageSound.Play();
                isCharged = false;
                Debug.Log("Total damage: " + damage * timePressed);
			}

            timePressed = 1f;
        }
    }

}
