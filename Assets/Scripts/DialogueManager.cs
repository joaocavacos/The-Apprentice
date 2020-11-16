using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text charName;
    public Text dialogue;

    public static DialogueManager instance;

    public GameObject dialogueBox;

    private Queue<string> sentences;

	void Awake()
	{
        instance = this;
	}

	void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){
		if (!dialogueBox.activeSelf)
		{
            Time.timeScale = 0;

            dialogueBox.SetActive(true);

            charName.text = dialogue.name;

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
		}
		else
		{
            DisplayNextSentence();
        }
       
	}

    public void DisplayNextSentence()
	{
        if(sentences.Count == 0)
		{
            EndDialogue();
            return;
		}

        string sentence = sentences.Dequeue();
        dialogue.text = sentence;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
	}

    IEnumerator TypeSentence (string sentence)
	{
        dialogue.text = "";

        foreach(char letter in sentence.ToCharArray())
		{
            dialogue.text += letter;
            yield return null;
		}
	}

    public void EndDialogue()
	{
        Time.timeScale = 1;
        dialogueBox.SetActive(false);
	}
}
