using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour
{
    GameObject loseText;
    private PlayerInput input;
    void Start()
    {
        loseText = GameObject.Find("LoseText");
        loseText.SetActive(false);
        input = loseText.GetComponent<PlayerInput>();
    }

    void Update()
    {

    }

    void TriggerLoss()
    {
        loseText.SetActive(true);
        input.actions["TryAgain"].performed += PlayerWantsToContinue;
    }
    void PlayerWantsToContinue(InputAction.CallbackContext context)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
