using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VirusUnit : MonoBehaviour
{
    GameTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<GameTimer>();
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected!");
        if (collision.gameObject.name == "Player")
        {
            OnDeath();
        }
    }

    public void Spawn()
    {
        Debug.Log("Spawned");
        this.gameObject.SetActive(true);
    }

    void OnDeath()
    {
        Debug.Log("On Death triggered");
        timer.Restoretime(20);
        this.gameObject.SetActive(false);
    }
}
