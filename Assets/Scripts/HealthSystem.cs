using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
	[SerializeField] int currentHearts;
	[SerializeField] int maxHearts;

    public Image[] hearts;
    
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int CurrentHearts
    {
	    get => currentHearts;
	    set
	    {
		    if (value > maxHearts) currentHearts = maxHearts;
		    if (value < maxHearts) currentHearts = value;
		    else if (value <= 0) value = 0;  
	    }
    }


    void Awake()
    {
	    currentHearts = maxHearts;
    }
    
    void Update()
	{
		CheckHP();
	}

    public void TakeDamage(int damage)
	{
		currentHearts -= damage;
	}

    private void CheckHP()
    {
	    for (int i = 0; i < hearts.Length; i++)
	    {
		    if(i < currentHearts)
		    {
			    hearts[i].sprite = fullHeart;
		    }
		    else
		    {
			    hearts[i].sprite = emptyHeart;
		    }

		    if (i < maxHearts)
		    {
			    hearts[i].enabled = true;
		    }
		    else
		    {
			    hearts[i].enabled = false;
		    }
	    }
    }
}
