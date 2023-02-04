using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class LoadLevel : MonoBehaviour
{
    private PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input = GetComponent<PlayerInput>();
        input.actions["Start"].performed += StartGame;
    }

    void StartGame(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("Level1");
    }
}
