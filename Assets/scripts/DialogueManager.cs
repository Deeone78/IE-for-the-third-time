using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<string> sentences;
    



    void Start()
    {
        sentences = new Queue<string>();
    
    
    
    }
    public void StartDialogue (Dialogue dialogue)
    {

        Debug.Log("starting a convertion with" + dialogue.name);

    }
    // Update is called once per frame
    
}
