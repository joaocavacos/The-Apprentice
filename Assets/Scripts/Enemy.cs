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
            Destroy(gameObject);
		}
    }

    public void TakeDamageEnemy(float damage)
	{
        enemy.enemyHP -= damage;
        enemy.enemyAnim.SetTrigger("Hurt");
        Debug.Log("Enemy hp: " + enemy.enemyHP);
	}
}
