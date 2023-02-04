using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VirusUnit : MonoBehaviour
{
    private int location;
    private string type;
    private List<Vector3> spawnPoints;
    GameTimer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Timer").GetComponent<GameTimer>();

        ///TODO populate this with actual values
        location = 0;
        type = "random";
        spawnPoints = new List<Vector3> // this is the list of limbs, could be stored somewhere else. Also coords need filling in.
        {
            new (122,1234,32423),
            new ( 1234,12342,234),
            new (1234,1234,234),
            new ( 1234,324,3242)
        };


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDeath()
    {
        timer.Restoretime(20);
    }
}
