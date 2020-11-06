using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHP;
    public float enemySpeed;

    public Animator enemyAnim;

    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(enemyHP <= 0)
		{
            Destroy(gameObject);
		}
    }

    public void TakeDamage(int damage)
	{
        enemyHP -= damage;
        Debug.Log("Damage taken");
	}
}
