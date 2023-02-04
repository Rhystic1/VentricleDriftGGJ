using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EasterEgg : MonoBehaviour
{
    private PlayerInput input;

    void Start()
    {
        float positionX = 11.5f;
        float positionY = 24.2f;
        float positionZ = 20.9f;

        GameObject camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(positionX, positionY, positionZ);

        input = GetComponent<PlayerInput>();
        input.actions["KonamiCode"].performed += KonamiCodePerformed;
    }

    void KonamiCodePerformed(InputAction.CallbackContext context)
    {
        GameObject camera = GameObject.Find("Camera");
        camera.transform.position = new Vector3(-0.65f, 22.82f, 20.3f);
    }
}



