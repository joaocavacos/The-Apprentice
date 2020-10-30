using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text charName;
    public Text dialogue;
    public Image charImage;

    public GameObject dialogueBox;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
        charImage = GetComponent<Image>();
    }

    public void StartDialogue(Dialogue dialogue){

        dialogueBox.SetActive(true);

        charName.text = dialogue.name;

        sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
            sentences.Enqueue(sentence);
		}

        DisplayNextSentence();
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
        dialogueBox.SetActive(false);
	}
}
