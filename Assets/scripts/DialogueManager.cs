using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;

    public Animator textBox1;
    public Text nameText;
    public Text dialogueText;

    void Start()
    {
        sentences = new Queue<string>();

     // textBox1 = GetComponentInChildren<Animator>();

    }
    public void StartDialogue(Dialogue dialogue)
    {
        textBox1.SetBool("Isopen", true);
        Debug.Log("starting a convertion with" + dialogue.name);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            DisplayNextSentence();


        }
    }
    public void DisplayNextSentence ()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;


        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
      //  dialogueText.text = sentence;
        IEnumerator TypeSentence (string sentence)
        {
            dialogueText.text  ="";
            foreach(char letter in sentence.ToCharArray())
            {
                dialogueText.text+= letter;
                yield return null;

            }
        
        
        
        }
        void EndDialogue()
        {
            // Debug.Log("End of conversati");
            textBox1.SetBool("Isopen", false);
        }
          
    }
    
    // Update is called once per frame
    
}
