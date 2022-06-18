using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigibody;
    public BoxCollider boxcollider;
    private Animator animator;
    private SpriteRenderer sprite;

    private AudioSource audio;
    public AudioClip jumpSong;

    //Game Inputs
    float horizontalInput = 0;
    float verticalInput = 0;
    float jumpInput = 0;

    //Movement
    public float moveSpeed;

    //move jump
    private float startPositionXJump;
    private float startPositionZJump;
    private float sumMoveJumpX;
    private float sumMoveJumpZ;
    public float moveSpeedJump;

    //jump
    private bool jumpdown;
    public float z;
    private bool canJump = true;
    public float delayJumpCd;
    public int jumpLevelFloor;
    private float jumpGravity;
    public float gravity ;
    public float jumpSpeedCD;
    private float jumpSpeed;

    //Movement Detection
    private bool isMoving = false;
    private bool isJumping = false;

    //Ground


    void Start()
    {
        audio = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rigibody = GetComponent<Rigidbody>();
        boxcollider = GetComponent<BoxCollider>();
        sprite = GetComponent<SpriteRenderer>();

    }
    void FixedUpdate()
    {

    }
    void Update()
    {
        get_input();
        moving();
        jumping();
        state_detection();
    }


    void moving()
    {
        if (!isJumping)
        {
            Vector3 move = new Vector3(horizontalInput, rigibody.velocity.y, verticalInput);
            move = move.normalized * moveSpeed;

            if (horizontalInput != 0 && verticalInput != 0)
            {
                move = move * 0.8f;
            }

            rigibody.velocity = move;
        }
    }

    void jumping()
    {
        if (isJumping)
        {
            boxcollider.enabled = false;
            if (jumpInput == 1)
            {
                jumpSpeed = jumpSpeedCD;
            }
            else
            {
                jumpSpeed = jumpSpeedCD / 2.5f;
            }
            z += jumpSpeed;            
        }
        if (z > jumpLevelFloor)
        {
            z -= jumpGravity;
            jumpGravity += gravity;
        }
        if (z <= jumpLevelFloor)
        {
            isJumping = false;
            z = jumpLevelFloor;
            jumpGravity = 0;
        }
        if (isJumping)
        {
            
            sumMoveJumpX += horizontalInput * moveSpeedJump;
            sumMoveJumpZ += verticalInput * moveSpeedJump;
            // test
            if (startPositionXJump + sumMoveJumpX > 4.623167f)
            {
                sumMoveJumpX = 4.623167f - startPositionXJump;
            }
            if (startPositionXJump + sumMoveJumpX < -4.478838f)
            {
                sumMoveJumpX = -4.478838f - startPositionXJump;
            }
            if (startPositionZJump + sumMoveJumpZ > 4.921855f)
            {
                sumMoveJumpZ = 4.921855f - startPositionZJump;
            }
            if (startPositionZJump + sumMoveJumpZ < -4.484418f)
            {
                sumMoveJumpZ = -4.484418f - startPositionZJump;
            }
            //
            rigibody.MovePosition(new Vector3(startPositionXJump + sumMoveJumpX, 0, startPositionZJump + sumMoveJumpZ + z));
        }
            
        

        else
        {
            boxcollider.enabled = true;
            startPositionXJump = rigibody.position.x;
            startPositionZJump = rigibody.position.z;
            sumMoveJumpX = 0;
            sumMoveJumpZ = 0;
        }
    }



    void get_input()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");

        animator.SetFloat("horizontalInput", horizontalInput);
        animator.SetFloat("verticalInput", verticalInput);
    }

    void state_detection()
    {
        //movement
        if (horizontalInput == 0 && verticalInput == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (jumpInput == 1)
        {
            if (!jumpdown)
            {
                if (jumpInput != 0 && canJump && isJumping == false)
                {
                    isJumping = true;
                    StartCoroutine(jumpCouldown());
                    audio.PlayOneShot(jumpSong);
                }
            }
            jumpdown = true;
            
        }
        else
        {
            jumpdown = false;
        }
        //jump
        
        animator.SetBool("moving", isMoving);
        animator.SetBool("jumping", isJumping);
    }


    IEnumerator jumpCouldown()
    {
        canJump = false;
        yield return new WaitForSeconds(delayJumpCd);
        canJump = true;
    }
}
