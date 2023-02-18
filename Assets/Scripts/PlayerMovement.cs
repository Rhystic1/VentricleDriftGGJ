using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    AudioDirector audioDirectorScript;

    Vector3 movement;

    [SerializeField]
    PlayerMovement m_PlayerMovement;
    CharacterController controller;
    public float speed = 9f;
    public float lateralSpeed = 15f;
    public float rotationSpeed = 2f;
    public float pitchSpeed = 124f;
    public float gravityScale = 0f;

    public Vector3 impulseForce;

    public GameObject timer;
    public PlayerInput input;
    public GameObject player;
    public GameTimer lossCondition;
    void Start()
    {
        // links up with the AudioDirector script to access the FMOD events
        audioDirectorScript = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<AudioDirector>();


        controller = GetComponent<CharacterController>();

        impulseForce = new Vector3(0f, 0f, 0f);

        timer = GameObject.Find("Timer");
        lossCondition = timer.GetComponent<GameTimer>();
        input = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    void Update()
    {
        movement = Vector3.zero;
        if (lossCondition.isGameLostBool == false)
        {
            this.MoveForward();

            // slight changes to the movement to incorperate the StrafeSpeed parameter

            if (input.actions["MoveUp"].IsInProgress() ||
            input.actions["MoveRight"].IsInProgress() ||
            input.actions["MoveLeft"].IsInProgress() ||
            input.actions["MoveDown"].IsInProgress())
            {
                audioDirectorScript.ChangeStrafeSpeed(1f);
                if (input.actions["MoveUp"].IsInProgress())
                {
                    this.MoveUp();
                }
                if (input.actions["MoveRight"].IsInProgress())
                {
                    this.MoveRight();
                }
                if (input.actions["MoveLeft"].IsInProgress())
                {
                    this.MoveLeft();
                }
                if (input.actions["MoveDown"].IsInProgress())
                {
                    this.MoveDown();
                }
            }
            else
            {
                audioDirectorScript.ChangeStrafeSpeed(0f);
            }

            //   for the pitch to incorperate the TurnSpeed perameter

            if (input.actions["PitchLeft"].IsInProgress() ||
            input.actions["PitchRight"].IsInProgress() ||
            input.actions["PitchUp"].IsInProgress() ||
            input.actions["PitchDown"].IsInProgress())
            {
                audioDirectorScript.ChangeTurnSpeed(1f);
                if (input.actions["PitchLeft"].IsInProgress())
                {
                    this.PitchLeft();
                }
                if (input.actions["PitchRight"].IsInProgress())
                {
                    this.PitchRight();
                }
                if (input.actions["PitchUp"].IsInProgress())
                {
                    this.PitchUp();
                }
                if (input.actions["PitchDown"].IsInProgress())
                {
                    this.PitchDown();
                }
            }
            else audioDirectorScript.ChangeTurnSpeed(0f);

            movement += Physics.gravity * gravityScale;
            controller.Move(movement * Time.deltaTime);
        }

        //detrimines the ships current forward velocity and turns it into a variable for controlling the EngineSpeed parameter
        Vector3 velocity = controller.velocity;
        Vector3 forward = transform.forward;
        float forwardVelocity = (Vector3.Dot(velocity, forward) / speed) / 2;
        audioDirectorScript.ChangeEngineSpeed(forwardVelocity);

    }

    void MoveForward()
    {
        Vector3 moveDirectionForward = transform.forward * speed;
        movement += moveDirectionForward;
    }

    void MoveLeft()
    {
        Vector3 moveDirectionLeft = -transform.right * lateralSpeed;
        movement += moveDirectionLeft;
    }

    void MoveRight()
    {
        Vector3 moveDirectionRight = transform.right * lateralSpeed;
        movement += moveDirectionRight;
    }

    void MoveUp()
    {
        Vector3 moveDirectionUp = transform.up * lateralSpeed;
        movement += moveDirectionUp;
    }

    void MoveDown()
    {
        Vector3 moveDirectionDown = -transform.up * lateralSpeed;
        movement += moveDirectionDown;
    }

    void PitchLeft()
    {
        Vector3 targetDirection = -transform.right;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion currentRotation = transform.rotation;
        Quaternion smoothRotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = smoothRotation;
    }

    void PitchRight()
    {
        Vector3 targetDirection = transform.right;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion currentRotation = transform.rotation;
        Quaternion smoothRotation = Quaternion.Slerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = smoothRotation;
    }

    void PitchUp()
    {
        Vector3 rotation = new Vector3(-pitchSpeed, 0, 0);
        transform.localRotation *= Quaternion.Euler(rotation * Time.deltaTime);
    }

    void PitchDown()
    {
        Vector3 rotation = new Vector3(pitchSpeed, 0, 0);
        transform.localRotation *= Quaternion.Euler(rotation * Time.deltaTime);
    }


}