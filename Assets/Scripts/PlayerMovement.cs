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
        speed = 0.01f;

        timer = GameObject.Find("Timer");
        lossCondition = timer.GetComponent<GameTimer>();
        player = GameObject.FindWithTag("Player");
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
        }
    }

    void MoveForward()
    {
        player.transform.position = player.transform.TransformPoint(speed, 0, 0);
    }
    void MoveUp()
    {
        player.transform.position = player.transform.TransformPoint(0, speed, 0);
    }
}
