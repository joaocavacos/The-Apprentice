using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float health;
    public int damage;

    private float timebtwDamage = 1.5f;

    public Slider bossHealth;
    public Text hpNumber;
    private Animator bossAnim;

	void Start()
	{
        bossAnim = GetComponent<Animator>();
	}

	void Update()
    {
        if(health <= 0)
		{
            Debug.Log("Boss has died");
		}

        if (timebtwDamage > 0) //The boss doesn't attack constantly
        {
            timebtwDamage -= Time.deltaTime;
        }

        bossHealth.value = health;
        hpNumber.text = Mathf.RoundToInt(health).ToString();
    }

    public void TakeDamageBoss(float damage)
	{
        health -= damage;
        Debug.Log("Boss took: " + damage);
	}
}
