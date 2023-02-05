using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    PlayerMovement m_PlayerMovement;
    public float posX;
    public float posY;
    public float posZ;
    public float speed;
    public float RotationSpeed = 2f;
    public float currentSpeed = 0.05f;
    public Rigidbody rb;
    public Vector3 impulseForce;

    public GameObject timer;
    public PlayerInput input;
    public GameObject player;
    public GameTimer lossCondition;
    // Start is called before the first frame update
    void Start()
    {
        posX = player.transform.position.x;
        posY = player.transform.position.y;
        posZ = player.transform.position.z;
        currentSpeed = 0.05f;

        rb = GetComponent<Rigidbody>();
        impulseForce = new Vector3(0f, 0f, 0f);

        timer = GameObject.Find("Timer");
        lossCondition = timer.GetComponent<GameTimer>();
        input = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lossCondition.isGameLostBool == false)
        {
            this.MoveForward();

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
            float rotationY = input.actions["RotatePlayer"].ReadValue<float>();
            this.RotatePlayer(rotationY);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        currentSpeed -= 0.03f;
        if (currentSpeed <= 0f)
        {
            currentSpeed = 0f;
        }

        if (currentSpeed == 0f)
        {
            return;
        }

        impulseForce = -collision.impulse / Time.fixedDeltaTime;
        rb.AddForce(impulseForce, ForceMode.Impulse);
        Vector3 closestPoint = collision.collider.ClosestPoint(transform.position);
        Vector3 direction = (transform.position - closestPoint).normalized;
        transform.position = closestPoint + direction * 0.5f;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (currentSpeed != speed)
        {
            currentSpeed += 0.02f;
        }
    }

    void MoveForward()
    {
        if (currentSpeed == 0f)
        {
            transform.position = transform.TransformPoint(0, 0, speed);
        }
        currentSpeed = Mathf.Lerp(currentSpeed, speed, Time.deltaTime);
        transform.position = transform.TransformPoint(0, 0, currentSpeed);
    }

    void MoveUp()
    {
        transform.position = transform.TransformPoint(0, currentSpeed, 0);
    }
    void MoveDown()
    {
        transform.position = transform.TransformPoint(0, -currentSpeed, 0);
    }
    void MoveLeft()
    {
        transform.position = transform.TransformPoint(-currentSpeed, 0, 0);
    }
    void MoveRight()
    {
        transform.position = transform.TransformPoint(currentSpeed, 0, 0);
 
    }
    void RotatePlayer(float rotationY)
    {
        Quaternion rotation = transform.rotation;
        rotation *= Quaternion.Euler(0,rotationY * RotationSpeed,0);
        transform.rotation = rotation;
    }
}
