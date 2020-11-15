using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    private int healAmmount = 30;
    
    private HealthSystem playerHp;

    void Awake()
    {
        playerHp = FindObjectOfType<HealthSystem>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerHp.currentHealth < playerHp.maxHealth)
        {
            Destroy(gameObject);
            playerHp.currentHealth += healAmmount;
        }
    }

}
