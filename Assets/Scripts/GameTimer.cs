using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameTimer : MonoBehaviour
{
    public Image fullImage;
    public float currentTime = 60f;
    public float totalTime = 60f;
    public float virusCountdown;
    public float timePercentage = 100.0f;
    public bool isGameLostBool = false;

    GameObject gameTimer;
    VirusMiddleManagement virusManager;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameObject.Find("Timer");
        virusManager = GameObject
            .Find("VirusManager")
            .GetComponent<VirusMiddleManagement>();
        fullImage = GetComponent<Image>();
        virusCountdown = 0f;
    }

    bool isGameLost()
    {
        return isGameLostBool;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            fullImage.fillAmount = currentTime / totalTime;
            timePercentage = (currentTime / totalTime) * 100.0f;
            virusCountdown += Time.deltaTime;
        }

        else
        {
            LoseGame loseScript = gameTimer.GetComponent<LoseGame>();
            isGameLostBool = true;
            timePercentage = 0.0f;
            loseScript.Invoke("TriggerLoss", 0);
        }
        if (virusCountdown > 60)
        {
            virusManager.Spawn();
        }
    }

    public void Restoretime(float time = 30)
    {
        currentTime += time;
        if (currentTime > 60) currentTime = 60;
    }
}