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
        if (playerHp.hpSlider.value < playerHp.hpSlider.maxValue)
        {
            Destroy(gameObject);
            playerHp.hpSlider.value += healAmmount;
        }
    }

}
