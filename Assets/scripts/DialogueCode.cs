using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class DialogueCode : MonoBehaviour
{
    /*
    
    [Header("Variables")]
    public int musicianDialogue;
    public int flamencoDialogue;
    public bool flamencoErrand2;
    public bool canQuest;
    public bool canQuestP2;
    public bool yes;
    public bool no;
    public bool inChoice;
    public bool inDialogue;
    public bool doneFlamenco;

    [Header("GameObjects")]
    public GameObject playerLive;
    public GameObject playerDead;
    public GameObject textBox;
    public GameObject textBoxBorder;
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject Canvas;

    [Header("Flamenco Text")] // got mixed up while codin
    public string mLine1 = "Hi there!";
    public string mLine2 = "Can you help me?";
    public string mLine3 = "I seem to have misplaced my dvd, it has my most precious memory";
    public string mLine4 = "If you find it, i would be so grateful";
    public string mLine5 = "Wait a minute. You went to the same flamenco college as me. Sm";
    public string mLine6 = "Well once you help me find this dvd, i'd love to have a dance with you";
    public string mLine7 = "Is that alright?";
    public string mLine8 = "Perfect!";
    public string mLine9 = "Aww. Maybe next time, see ya later then!";
    public string mLine10 = "Thank you, lets hurry up and find that dvd!";
    public string mLine11 = "Yay. You found it! My DVD.";
    public string mLine12 = "Thank you so much Dude, i've been looking for this for ages.";
    public string mLine13= "Well. Now that thats sorted out, may i have this dance? The DVD has the dance we were taught on it, so you can watch that before we dance.";
    public string mLine14 = "";

    public Text textElement;

    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        textBoxBorder.SetActive(false);
        canQuest = true;
        inDialogue = false;
        flamencoErrand2 = false;
        yes = false;
        no = false;
        musicianDialogue = 0;
        flamencoDialogue = 0;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(inDialogue == true)
        {
            EnterDialogue();
            if (inChoice == false && Input.GetKeyDown(KeyCode.E))
            {
                flamencoDialogue++;
            }
            
            Dialogue();

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if ((canQuest == true || canQuestP2 == true) && other.tag == "Quest 1" && doneFlamenco == false)
        {
            inDialogue = true;
        }
    }

    private void Dialogue() 
    { 
        switch (flamencoDialogue)
        {
            case 0:
                textElement.text = mLine1;
                break;
            case 1:
                textElement.text = mLine2;
                break;
            case 2:
                textElement.text = mLine3;
                break;
            case 3:
                textElement.text = mLine4;
                break;
            case 4:
                textElement.text = mLine5;
                break;
            case 5:
                textElement.text = mLine6;
                break;
            case 6:
                textElement.text = mLine7;
                yesButton.SetActive(true);
                noButton.SetActive(true);
                inChoice = true;
                break;
            case 7 when yes:
                textElement.text = mLine8;
                break;
            case 7 when no:
                textElement.text = mLine9;
                break;
            case 8 when yes:
                textElement.text = mLine10;
                break;
            case 8 when no:
                ExitDialogue();
                flamencoDialogue = 0;
                canQuest = true;
                break;
            case 9:
                flamencoDialogue++;
               // Canvas.GetComponent<MissionScreen>().flamencoPart2 = true;
                ExitDialogue();
                break;
            case 10:
                textElement.text = mLine11;
                break;
            case 11:
                textElement.text = mLine12;
                break;
            case 12:
                textElement.text = mLine13;
                break;
            case 13:
                textElement.text = mLine14;
                doneFlamenco = true;
                //Canvas.GetComponent<MissionScreen>().flamencoPart3 = true;
                break;
            case 14:
                ExitDialogue();
                break;
            default:
                break;
        }

        
        //add part 2 of dialogue code, which is simply the lines of text, add multiple choice ability

    }

    private void EnterDialogue()
    {
       // playerLive.GetComponent<PlayerLiveControl>().canMove = false;
       // playerDead.GetComponent<PlayerDeadControl>().canMove = false;
        textBox.SetActive(true);
        textBoxBorder.SetActive(true);
    }

    private void ExitDialogue()
    {
       // playerLive.GetComponent<PlayerLiveControl>().canMove = true;
      //  playerDead.GetComponent<PlayerDeadControl>().canMove = true;
        textBox.SetActive(false);
        textBoxBorder.SetActive(false);
        inDialogue = false;
        canQuest = false;
        yes = false;
        no = false;
    }

    public void ButtonYesFlamenco()
    {
        yes = true;
        flamencoDialogue++;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;
        
    }

    public void ButtonNoFlamenco()
    {
        no = true;
        flamencoDialogue++;
        yesButton.SetActive(false);
        noButton.SetActive(false);
        inChoice = false;

    }
    */
}
