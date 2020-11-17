using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyHP;
    public float enemySpeed;
    public float enemyDamage;

    private Animator enemyAnim;
    private Enemy enemy;

    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if(enemy.enemyHP <= 0)
		{
            Debug.Log("Enemy destroyed");
            Destroy(gameObject);
		}
    }

    public void TakeDamageEnemy(float damage)
	{
        enemy.enemyHP -= damage;
        Debug.Log("Enemy took some damage: " + damage);
        Debug.Log("Enemy hp: " + enemy.enemyHP);
	}
}
