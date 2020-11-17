using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;

    private Enemy enemy;
    private HealthSystem health;
    private Animator animator;

    float distanceEnemies;
    public float distancetoAttack;
    public float playerOffset;
    public float rangeAttack;
    private float distance;

    private Vector3 enemyDirection;

    [SerializeField] bool canAttack = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyDirection = (player.position - enemy.transform.position).normalized;
        
        distanceEnemies = Vector2.Distance(player.position, enemy.transform.position);
        distance = distanceEnemies - playerOffset;

        if (distanceEnemies < distancetoAttack)
        {
            //enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.position, enemy.enemySpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.transform.position + enemyDirection * distance, enemy.enemySpeed * Time.deltaTime);
        }
        if(distanceEnemies <= rangeAttack && canAttack)
		{
            animator.SetBool("isRunning", false);
            StartCoroutine(Attack());
		}
        
    }

    private IEnumerator Attack() //Corountine for attacking the player, 2 second per attack
	{
        animator.SetTrigger("Attack");
        health.TakeDamage(enemy.enemyDamage);
        canAttack = false;
        yield return new WaitForSeconds(1.25f);
        canAttack = true;
        Debug.Log("Enemy attacked");
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distancetoAttack);
	}
}
