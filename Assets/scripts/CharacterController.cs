using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip collect;
    public AudioSource sfxPlayer;
    public static event Action OnCollected;

    GameObject cam;
    bool npcDistance = false;
    bool npcDistance1 = false;
    bool npcDistance2 = false;
    bool npcDistance3 = false;
    bool npcDistance4 = false;

    Rigidbody myRigidbody;
    bool isOnGround = false;
    bool isPortalin = false;
    bool isPortalin1 = false;
    public GameObject groundChecker;
    public GameObject areInPort;
    public LayerMask groundLayer;
    public float jumpForce = 3000.0f;
    public LayerMask player;
    public LayerMask portal;
    public LayerMask portal1;
    public LayerMask player1;
    public LayerMask player2;
    public LayerMask player3;
    public LayerMask player4;
    public float maxSprint = 5.0f;
    float sprintTimer;
    Animator myAnim;

    int pickupCount = 0;
    public Text scoreCounter;
    public GameObject key;
    bool keyCollected = false;
    public Transform target;
    public DissolveSphere[] paintedObjects;

    void Start()
    {

        //  Cursor.lockState = CursorLockMode.Locked;
        paintedObjects = FindObjectsOfType<DissolveSphere>();
        myAnim = GetComponentInChildren<Animator>();
        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
        sprintTimer = maxSprint;
        
    }

    // Update is called once per frame
    float rotation = 0.0f;
    public float normalSpeed = 1f;
    public float sprintSpeed = 20f;

    float maxSpeed;
    
    float camRoatation = 0.0f;
    float rotaiotionSpeed = 5.0f;
    float camRotationSpeed = 5.0f;
    public GameObject convoStart;
    public GameObject convoStart1;
    public GameObject convoStart2;
    public GameObject convoStart3;
    public GameObject convoStart4;


    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 1f, groundLayer);
        myAnim.SetBool("isOnGround", isOnGround);
        npcDistance = Physics.CheckSphere(groundChecker.transform.position, 10.1f, player);
        npcDistance1 = Physics.CheckSphere(groundChecker.transform.position, 10.1f, player1);
        npcDistance2 = Physics.CheckSphere(groundChecker.transform.position, 10.1f, player2);
        npcDistance3 = Physics.CheckSphere(groundChecker.transform.position, 10.1f, player3);
        npcDistance4 = Physics.CheckSphere(groundChecker.transform.position, 10.1f, player4);
        isPortalin = Physics.CheckSphere(groundChecker.transform.position, 1f, portal);
        isPortalin1 = Physics.CheckSphere(groundChecker.transform.position, 1f, portal1);
        // Debug.Log(CompleteCheck());

        if (npcDistance == true)
        {
            convoStart.SetActive(true);


        }
        else
        {
            convoStart.SetActive(false);
        }
        if (npcDistance1 == true)
        {
            convoStart1.SetActive(true);


        }
        else
        {
            convoStart1.SetActive(false);
        }
        if (npcDistance2 == true)
        {
            convoStart2.SetActive(true);


        }
        else
        {
            convoStart2.SetActive(false);
        }

        if (npcDistance3 == true)
        {
            convoStart3.SetActive(true);


        }
        else
        {
            convoStart3.SetActive(false);
        }
        if (npcDistance4 == true)
        {
            convoStart4.SetActive(true);


        }
        else
        {
            convoStart4.SetActive(false);
        }

        if (npcDistance != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //   npcDistance.gameObject.GetComponent<NPC>().TriggerDialogue();
            }
        }

        if (Input.GetKey(KeyCode.S))
        {


        }

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
            myAnim.SetTrigger("jumped");
        }


        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }

        }
        
        
        if (isPortalin == true)
        {

            Debug.Log("you did it");

            SceneManager.LoadScene(3);
        }


        if(isPortalin1 == true)
        {

            Debug.Log("you did it");

            SceneManager.LoadScene(2);
        }





        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myAnim.SetFloat("speed", newVelocity.magnitude);

        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);
        /*if (Input.GetKey(KeyCode.S))
        {
            rotation += 180;

        }

        */


        rotation = rotation + Input.GetAxis("Mouse X") * rotaiotionSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        //Debug.Log(Input.GetAxis("Mouse Y"));

        target.position = new Vector3(target.position.x, target.position.y + Input.GetAxis("Mouse Y"), target.position.z);

        Mathf.Clamp(rotation, -10, 10);




        //camRoatation = camRoatation + Input.GetAxis("Mouse Y") * camRotationSpeed *-1;
        //camRoatation = Mathf.Clamp(camRoatation,-40.0f,40.0f);
        //cam.transform.localRotation = Quaternion.Euler(new Vector3(camRoatation, 0.0f,0.0f));
    }

    bool CompleteCheck()
    {
        for (int i = 0; i < paintedObjects.Length; i++)
        {
            if (paintedObjects[i].painted == false)
            {
                return false;
            }
        }

        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // SceneManager.LoadScene(1);

            //Debug.Log("hit");
            myRigidbody.AddForce(transform.up * jumpForce*1.5f);
            myAnim.SetTrigger("jumped");

        }


    }
}
