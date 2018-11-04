using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour {

    public Text txtName;
    public Text txtDialogue;

    public Animator animator;

    private Queue<string> sentences;
	
	void Start () {
        sentences = new Queue<string>();
	}
	
    public void StartDialogue(dialogue Dialogue)
    {
        //play animation to display the dialogue box.
        animator.SetBool("isOpen", true);

        txtName.text = Dialogue.name;

        //Clear any previous conversations.
        sentences.Clear();

        //go through each sentence.
        foreach (string sentence in Dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        //show the next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        } 

        //pull the next sentence out of the Queue.
        string sentence = sentences.Dequeue();

        //stop typing the previous sentence.
        StopAllCoroutines();

        //start typing the current sentence.
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        txtDialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            txtDialogue.text += letter;

            //wait 1 frame
            yield return null;
        }
    }

    public void EndDialogue()
    {
        //play animation to hide the dialogue box.
        animator.SetBool("isOpen", false);
    }
}
