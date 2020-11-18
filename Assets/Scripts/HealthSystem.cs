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
	ActionHandler changeScene;

	public AudioSource playerHurt;

    void Awake()
    {
		changeScene = GetComponent<ActionHandler>();
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
		    else if (value <= 0) currentHealth = 0;  
	    }
    }
    

    public void TakeDamage(float damage) //Take damage from attack
	{
		playerHurt.Play();
		CurrentHealth -= damage;
		Debug.Log("Damage taken from enemy: " + damage);
	}

	public void DeathCheck() //Checks if is dead
	{
		if(CurrentHealth <= 0)
		{
			changeScene.DeadScreen();
		}
	}
    
}
