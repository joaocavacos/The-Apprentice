using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine.Utility;
using Cinemachine;
public class BossBattle : MonoBehaviour
{
    public GameObject boss;
	public GameObject block;

	ActionHandler changeScene;

	public CinemachineTargetGroup targetGroup;

	private void Start()
	{
		changeScene = GetComponent<ActionHandler>();
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player") && boss != null)
		{
			Debug.Log("Boss battle start");
			boss.SetActive(true);
			block.SetActive(true);
			targetGroup.AddMember(boss.transform, 2, 6);
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
			changeScene.Victory();
		}
	}
}
