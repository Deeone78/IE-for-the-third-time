using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float slideSpeed;
    public float wallrunSpeed;

    private float desiredMoveSpeed;
    private float lastDesiredMoveSpeed;

    public float speedIncreaseMultiplier;
    public float slopeIncreaseMultiplier;

    public float groundDrag;

    private float currentMoveSpeed;

    public bool sliding;

    public float gravforce;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Crouching")]
    public float crouchSpeed;
    public float crouchYScale;
    private float startYScale;
    public bool crouching;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode crouchKey = KeyCode.LeftControl;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    bool isOnGround = false;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    [Header("Slope Handling")]
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    [Header("Boost values")]
    public float boostSpeed;
    private float currentBoostTimer;
    public float boosttimer;
    
   // public bool boosting;

    [Header("Wall Running")]
    public bool wallrunning;

    [Header("Refrences")]
    public Transform orientation;
    Animator myAnim;
    

    [Header("GAMESETTINGS")]
    public bool lvlstart;
    public bool lvlend;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        idle,
        walking,
        sprinting,
        crouching,
        wallrunning,
        sliding,
        air
    }

    

    

    private void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;

        startYScale = transform.localScale.y;

        currentBoostTimer = boosttimer;
    }

    private void Update()
    {
        // ground check
       // grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        StateHandler();
        gravity();
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.05f, groundLayer);
        
        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
          //  myAnim.SetTrigger("jumped");
            rb.AddForce(transform.up* jumpForce);
              
        }
        //sets game state
        if (lvlend)
        {
            lvlstart = false;
        }
        //starts boost
      /*  if (boosting == true)
        {
            Boosting();
        }

        // handle drag
      
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        */
       // anim.SetBool("grounded", grounded);
        myAnim.SetFloat("Speed", rb.velocity.magnitude);
       // anim.SetBool("slide start", sliding);

    }

   /* private void FixedUpdate()
    {
        MovePlayer();
    }
*/
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
      /*  if (Input.GetKey(jumpKey) && readyToJump && grounded) //Input.GetKey(jumpKey) && readyToJump && OnSlope
        {
            readyToJump = false;

            Jump();

            //resets jump after jumping so you can hold space to regester next jump
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // start crouch
        if (Input.GetKeyDown(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            crouching = true;
        }

        // stop crouch
        if (Input.GetKeyUp(crouchKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            crouching = false;
        }
        */
    }

    private void StateHandler()
    {
        //Wallrunning
       /* if (wallrunning)
        {
            state = MovementState.wallrunning;
            if (!boosting)
            {
                desiredMoveSpeed = moveSpeed;
            }
            else
            {
                desiredMoveSpeed = wallrunSpeed;
            }
        }

        // Sliding
        else if (sliding && !wallrunning)
        {
            state = MovementState.sliding;

            if (OnSlope() && rb.velocity.y < 0.1f)
            {
                if (!boosting)
                {
                    desiredMoveSpeed = slideSpeed;
                }
            }
            else if(OnSlope() && rb.velocity.y > 0.1f)
            {
                if (!boosting)
                {
                    desiredMoveSpeed = moveSpeed;
                }
            }
        }

        // Crouching
      /*  else if (Input.GetKey(crouchKey) && !wallrunning)
        {
            state = MovementState.crouching;
            desiredMoveSpeed = crouchSpeed;
        }

        // Sprinting
        else if (grounded && Input.GetKey(sprintKey) && !wallrunning && (horizontalInput != 0 || verticalInput != 0))
        {
            state = MovementState.sprinting;
            desiredMoveSpeed = sprintSpeed;
          //  anim.SetBool("running", true);
        }

        // Walking
        else if (grounded && (horizontalInput != 0 || verticalInput != 0) || OnSlope() && (horizontalInput != 0 || verticalInput != 0))
        {
            state = MovementState.walking;
            desiredMoveSpeed = walkSpeed;
            rb.useGravity = true;
           // anim.SetBool("running", false);
        }
        
        //idle
        else if (grounded && horizontalInput == 0 && verticalInput == 0 || OnSlope() && horizontalInput == 0 && verticalInput == 0)
        {
            state = MovementState.idle;
            desiredMoveSpeed = 0f;
            rb.useGravity = true;
        }

        // Air
        else
        {
            state = MovementState.air;
            if (!boosting)
            {
                desiredMoveSpeed = moveSpeed;
            }
        }

        // check if desiredMoveSpeed has changed drastically
        if (Mathf.Abs(desiredMoveSpeed - lastDesiredMoveSpeed) > 7f && moveSpeed != 0)
        {
            StopAllCoroutines();
            StartCoroutine(SmoothlyLerpMoveSpeed());
        }
        else
        {
            moveSpeed = desiredMoveSpeed;
        }

        lastDesiredMoveSpeed = desiredMoveSpeed;
    }

    private IEnumerator SmoothlyLerpMoveSpeed()
    {
        // smoothly lerp movementSpeed to desired value
        float time = 0;
        float difference = Mathf.Abs(desiredMoveSpeed - moveSpeed);
        float startValue = moveSpeed;
       

        while (time < difference)
        {
            moveSpeed = Mathf.Lerp(startValue, desiredMoveSpeed, time / difference);
            

            if (OnSlope())
            {
                float slopeAngle = Vector3.Angle(Vector3.up, slopeHit.normal);
                float slopeAngleIncrease = 1 + (slopeAngle / 90f);

                time += Time.deltaTime * speedIncreaseMultiplier * slopeIncreaseMultiplier * slopeAngleIncrease;
            }
            else
            {
                time += Time.deltaTime * speedIncreaseMultiplier; 
            }
            yield return null;
        }

        moveSpeed = desiredMoveSpeed;
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on slope
      /*  if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection(moveDirection) * moveSpeed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        // on ground
        
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // in air
       /*
       
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        // turn gravity off while on slope
        rb.useGravity = !OnSlope();
        */
    }

    private void SpeedControl()
    {
        // limiting speed on slope
      /*  if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > moveSpeed)
            {
                rb.velocity = rb.velocity.normalized * moveSpeed;
            }
        }

        // limiting speed on ground or in air
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if needed
            if (flatVel.magnitude > moveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }
        */    
    }
        /*
    private void Jump()
    {
       // exitingSlope = true;
     //   anim.SetTrigger("Jump");

        //reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        /*if (!OnSlope())
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
        if (OnSlope())
        {
            rb.AddForce(transform.up * (jumpForce + 5f), ForceMode.Impulse);
        }
        
        if(moveSpeed < 49f)
        {
            moveSpeed += 1f;
        }
    }
    /*
    private void ResetJump()
    {
        readyToJump = true;
       // anim.SetBool("Jump", false);

      //  exitingSlope = false;
    }
    
    public bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
        
    }
    */
    /*
    public Vector3 GetSlopeMoveDirection(Vector3 direction)
    {
        return Vector3.ProjectOnPlane(direction, slopeHit.normal).normalized;
    }

    public void BoostStart()
    {
        boosting = true;
        currentMoveSpeed = moveSpeed;
    }

    private void Boosting()
    {
        //ends boost when timer ends
        if (currentBoostTimer <= 0f)
        {
            BoostEnd();
        }
        
        //boost
        moveSpeed = moveSpeed + boostSpeed;
        currentBoostTimer -= Time.deltaTime;
    }

    private void BoostEnd()
    {
        boosting = false;
        currentBoostTimer = boosttimer;
        moveSpeed = currentMoveSpeed;
    }
    */
    private void gravity()
    {
        rb.AddForce(transform.up * -gravforce, ForceMode.Force);
    }
}