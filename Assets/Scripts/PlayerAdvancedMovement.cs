using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//basic script to handle crouching and sprinting

public class PlayerAdvancedMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprintSpeed = 10f;
    public float moveSpeed = 5f;
    public float crouchSpeed = 2f;

    private Transform lookRoot;
    private float standingHeight = 1.6f;
    private float crouchingHeight = 1f;
    private bool isCrouching;

    // Start is called before the first frame update
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        lookRoot = transform.GetChild(0); //look root is child of player 
    }

    void Update()
    {
        Sprint();
        Crouch();
    }

    //will circle back here a later stage to add stamina 
    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            playerMovement.speed = moveSpeed;
        }
    }
    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                lookRoot.localPosition = new Vector3(0f, standingHeight, 0f); //default standing height is 
                playerMovement.speed = moveSpeed;

                isCrouching = false;
            }
            else
            {
                lookRoot.localPosition = new Vector3(0f, crouchingHeight, 0f);
                playerMovement.speed = crouchSpeed;

                isCrouching = true;
            }
        }
    }
}
