using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHeal : MonoBehaviour
{
    private float healAmmount = 30f;
    
    private HealthSystem playerHp;

    void Awake()
    {
        playerHp = FindObjectOfType<HealthSystem>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerHp.CurrentHealth < playerHp.maxHealth)
        {
            Destroy(gameObject);
            playerHp.CurrentHealth += healAmmount;
        }
    }

}
