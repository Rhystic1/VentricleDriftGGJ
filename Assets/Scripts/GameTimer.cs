using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Image fullImage;
    public float currentTime = 60f;
    public float totalTime = 60f;
    public float timePercentage = 100.0f;
    public bool isGameLostBool = false;

    GameObject gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GameObject.Find("Timer");
        fullImage = GetComponent<Image>();
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
        }

        else
        {
            LoseGame loseScript = gameTimer.GetComponent<LoseGame>();
            isGameLostBool = true;
            timePercentage = 0.0f;
            loseScript.Invoke("TriggerLoss", 0);
        }
    }
}