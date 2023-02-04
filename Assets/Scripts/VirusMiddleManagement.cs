using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMiddleManagement : MonoBehaviour
{
    public VirusUnit virusUnitPreFab;
    public List<VirusUnit> unitList;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 50;
        int difficulty = 2;
        unitList = new List<VirusUnit>();
        for (int i = 0; i < difficulty; i++)
        {
            unitList.Add(Instantiate(virusUnitPreFab, transform));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        { 
            
        }
    }
}
