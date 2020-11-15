using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;

    private Enemy enemy;

    float distanceEnemies;
    public float distancetoAttack;


    void Start()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceEnemies = Vector2.Distance(player.position, enemy.transform.position);

        if (distanceEnemies < distancetoAttack)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, player.position, enemy.enemySpeed * Time.deltaTime);
        }
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distancetoAttack);
	}
}
