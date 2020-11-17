using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBattle : MonoBehaviour
{
    public GameObject boss;
	public GameObject block;

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && boss != null)
		{
			Debug.Log("Boss battle start");
			boss.SetActive(true);
			block.SetActive(true);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player") && boss != null)
		{
			boss.SetActive(false);
			block.SetActive(false);
		}
	}

	void Update()
	{
		if(boss == null)
		{
			boss = null;
			//SceneManager.LoadScene("Victory Screen");
		}
	}
}
