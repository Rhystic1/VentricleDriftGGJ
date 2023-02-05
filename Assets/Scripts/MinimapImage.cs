using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapImage : MonoBehaviour
{
    public GameTimer gameTimer;
    public Image miniMap;

    public Sprite fullHealth; 
    public Sprite highHealth;
    public Sprite midHealth;
    public Sprite lowHealth;
    public Sprite noHealth;

    // Start is called before the first frame update

    void Start()
    {
        fullHealth = Resources.Load<Sprite>("MiniMapFullHealth");
        highHealth = Resources.Load<Sprite>("MiniMapHighHealth");
        midHealth = Resources.Load<Sprite>("MiniMapMidHealth");
        lowHealth = Resources.Load<Sprite>("MiniMapLowHealth");
        noHealth = Resources.Load<Sprite>("MiniMapNoHealth");

        gameTimer = GameObject.Find("Timer").GetComponent<GameTimer>();
        miniMap = GameObject.Find("Image").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer.timePercentage >= 75)
        {
            miniMap.sprite = fullHealth;
        }

        if ((gameTimer.timePercentage <= 74) && (gameTimer.timePercentage >= 50))
        {
            miniMap.sprite = highHealth;
        }

        if ((gameTimer.timePercentage <= 49) && (gameTimer.timePercentage >= 25))
        {
            miniMap.sprite = midHealth;
        }

        if ((gameTimer.timePercentage <= 24) && (gameTimer.timePercentage >= 1))
        {
            miniMap.sprite = lowHealth;
        }

        if (gameTimer.timePercentage == 0)
        {
            miniMap.sprite = noHealth;
        }
    }
}
