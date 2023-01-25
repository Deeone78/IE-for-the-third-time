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
    
    Rigidbody myRigidbody;
    bool isOnGround = false;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 3000.0f; 
    public float maxSprint = 5.0f;
    float sprintTimer;
    Animator myAnim;

    int pickupCount = 0;
    public Text scoreCounter;
    public GameObject key;
    bool keyCollected = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

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
    

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        myAnim.SetBool("isOnGround", isOnGround);


        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up* jumpForce);
        }
       
        
        if (Input.GetKey(KeyCode.LeftShift)&& sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }else
        {   
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift)==false){
                sprintTimer = sprintTimer + Time.deltaTime;
            }

        }
        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        Vector3 newVelocity = (transform.forward * Input.GetAxis("Vertical") * maxSpeed) + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myAnim.SetFloat("speed", newVelocity.magnitude);

        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

      

        rotation = rotation + Input.GetAxis("Mouse X") * rotaiotionSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        camRoatation = camRoatation + Input.GetAxis("Mouse Y") * camRotationSpeed *-1;
        camRoatation = Mathf.Clamp(camRoatation,-40.0f,40.0f);
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRoatation, 0.0f,0.0f));
    }
}
