using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public float currentHealth;
	public float maxHealth;

	public Slider hpSlider;

    void Awake()
    {
		currentHealth = hpSlider.value;
		maxHealth = hpSlider.maxValue;
		currentHealth = maxHealth;
    }
    
    void Update()
    {
		DeathCheck();
    }
    
    public float CurrentHealth //get and set for currentHealth
    {
	    get => currentHealth;
	    set
	    {
		    if (value > maxHealth) currentHealth = maxHealth;
		    if (value < maxHealth) currentHealth = value;
		    else if (value <= 0) value = 0;  
	    }
    }
    

    public void TakeDamagePlayer(float damage) //Take damage from attack
	{
		hpSlider.value -= damage;
	}

	public void DeathCheck() //Checks if is dead
	{
		if(hpSlider.value <= 0)
		{
			Debug.Log("Dead");
		}
	}
    
}
