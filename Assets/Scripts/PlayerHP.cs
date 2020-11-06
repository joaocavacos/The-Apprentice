using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int hp;
    public int numberHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    //public Sprite halfHeart;
    public Sprite emptyHeart;

	void Update()
	{
		if(hp > numberHearts)
		{
			hp = numberHearts;
		}

		for (int i = 0; i < hearts.Length; i++)
		{
			if(i < hp)
			{
				hearts[i].sprite = fullHeart;
			}
			else
			{
				hearts[i].sprite = emptyHeart;
			}

			if (i < numberHearts)
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
