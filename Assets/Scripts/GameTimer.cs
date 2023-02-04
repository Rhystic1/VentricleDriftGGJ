using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Image fullImage;
    public float startingTime = 60f;
    public float totalTime = 60f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameTimer = GameObject.Find("Timer");
        fullImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startingTime > 0)
        {
            startingTime -= Time.deltaTime;
            fullImage.fillAmount = startingTime / totalTime;
        }
    }
}
