using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public float health;

    public Slider bossHealth;
    public Text hpNumber;

    private Animator animator;

    void Start()
	{
        animator = GetComponent<Animator>();
	}

	void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Boss died");
            StartCoroutine(Die());
        }

        bossHealth.value = health;
        hpNumber.text = Mathf.RoundToInt(health).ToString();
    }

    public void TakeDamageBoss(float damage)
	{
        health -= damage;
	}

    private IEnumerator Die()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    
}
