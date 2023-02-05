using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class VirusMiddleManagement : MonoBehaviour
{
    public List<int> unitList;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        int difficulty = 2;
        unitList = new List<int>();
        for (int i = 0; i < difficulty; i++)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            string name = string.Format("Virus{0}", i);
            if (unitList.Contains(i) && !GameObject.Find(name).activeSelf)
            {
                unitList.Remove(i);
            }
        }
    }

    public void Spawn()
    {
        Random rnd = new Random();
        int virusIndex = rnd.Next(0, 4);
        while (unitList.Contains(virusIndex) && unitList.Count < 4)
        {
            virusIndex = rnd.Next(0, 4);
        }
        string name = string.Format("Virus{0}", virusIndex);
        Debug.Log("spawning");
        Debug.Log(name);
        VirusUnit virus = GameObject.Find(name).GetComponent<VirusUnit>();
        virus.Spawn();
        unitList.Add(virusIndex);
    }
}
