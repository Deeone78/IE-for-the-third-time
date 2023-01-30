using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;

    //public Animator 
    public Text nameText;
    public Text dialogueText;

    void Start()
    {
        sentences = new Queue<string>();

       // myAnim = GetComponentInChildren<Animator>();

    }
    public void StartDialogue(Dialogue dialogue)
    {
        Animator.SetBool("Isopen", true);
      //  Debug.Log("starting a convertion with" + dialogue.name);

        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence ()
    {
        if(sentences.Count == 0)
        {
                EndDialogue();
                return;


        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        
        void EndDialogue()
        {
            // Debug.Log("End of conversati");
            Animator.SetBool("Isopen", false);
        }
          
    }
    
    // Update is called once per frame
    
}
