using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
	private bool playerinRange;

	//public GameObject dialogueBox;

	void Update()
	{
		if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && playerinRange == true )
		{
			TriggerDialogue();
			Debug.Log("A");
		}
		/*
		else if(playerinRange == false)
		{
			ExitDialogue();
		}
		*/
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerinRange = true;
			Debug.Log("Player in range");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			playerinRange = false;
			Debug.Log("Player left range");
		}


	}

	public void TriggerDialogue()
	{
		DialogueManager.instance.StartDialogue(dialogue);
	}

	public void ExitDialogue()
	{
		DialogueManager.instance.EndDialogue();
	}
    
}
