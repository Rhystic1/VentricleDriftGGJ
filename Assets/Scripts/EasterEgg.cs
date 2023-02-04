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
        if (context.action.name == "KonamiCode")
        {
            input.actions["KonamiCode1"].performed += KonamiCode1Performed;
            input.actions["KonamiCode"].performed -= KonamiCodePerformed;
        }
    }

    void KonamiCode1Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode1")
        {
            input.actions["KonamiCode2"].performed += KonamiCode2Performed;
            input.actions["KonamiCode1"].performed -= KonamiCode1Performed;
        }
    }

    void KonamiCode2Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode2")
        {
            input.actions["KonamiCode3"].performed += KonamiCode3Performed;
            input.actions["KonamiCode2"].performed -= KonamiCode2Performed;
        }
    }
    void KonamiCode3Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode3")
        {
            input.actions["KonamiCode4"].performed += KonamiCode4Performed;
            input.actions["KonamiCode3"].performed -= KonamiCode3Performed;
        }
    }

    void KonamiCode4Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode4")
        {
            input.actions["KonamiCode5"].performed += KonamiCode5Performed;
            input.actions["KonamiCode4"].performed -= KonamiCode4Performed;
        }
    }
    void KonamiCode5Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode5")
        {
            input.actions["KonamiCode6"].performed += KonamiCode6Performed;
            input.actions["KonamiCode5"].performed -= KonamiCode5Performed;
        }
    }

    void KonamiCode6Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode6")
        {
            input.actions["KonamiCode7"].performed += KonamiCode7Performed;
            input.actions["KonamiCode6"].performed -= KonamiCode6Performed;
        }
    }
    void KonamiCode7Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode7")
        {
            input.actions["KonamiCode8"].performed += KonamiCode8Performed;
            input.actions["KonamiCode7"].performed -= KonamiCode7Performed;
        }
    }
    void KonamiCode8Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode8")
        {
            input.actions["KonamiCode9"].performed += KonamiCode9Performed;
            input.actions["KonamiCode8"].performed -= KonamiCode8Performed;
        }
    }

    void KonamiCode9Performed(InputAction.CallbackContext context)
    {
        if (context.action.name == "KonamiCode9")
        {
            GameObject camera = GameObject.Find("Camera");
            camera.transform.position = new Vector3(-0.65f, 22.82f, 20.3f);
            input.actions["KonamiCode9"].performed -= KonamiCode9Performed;
        }
    }
}



