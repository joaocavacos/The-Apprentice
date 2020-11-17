using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	public float currentHealth;
	public float maxHealth;

	public Slider hpSlider;
	public Text numberHp;

    void Awake()
    {
		hpSlider.maxValue = maxHealth;
		currentHealth = maxHealth;
    }
    
    void Update()
    {
		hpSlider.value = CurrentHealth;
		numberHp.text = Mathf.RoundToInt(hpSlider.value).ToString();
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
    

    public void TakeDamage(float damage) //Take damage from attack
	{
		CurrentHealth -= damage;
		Debug.Log("Damage taken from enemy: " + damage);
	}

	public void DeathCheck() //Checks if is dead
	{
		if(CurrentHealth <= 0)
		{
			Debug.Log("Dead");
		}
	}
    
}
