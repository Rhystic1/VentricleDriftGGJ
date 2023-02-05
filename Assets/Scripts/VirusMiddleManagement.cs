using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class VirusMiddleManagement : MonoBehaviour
{
    public List<VirusUnit> unitList;
    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        int difficulty = 4;
        unitList = this.gameObject.GetComponentsInChildren<VirusUnit>(true).ToList();
        for (int i = 0; i < difficulty; i++)
        {
            if (difficulty == 4) unitList[i].Spawn();
            else unitList[Random.Range(0, unitList.Count)].Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Spawn()
    {
        if (!unitList.Exists(i => !i.gameObject.activeSelf)) return;
        int virusIndex = Random.Range(0, unitList.Count);
        while (unitList[virusIndex].gameObject.activeSelf)
        {
            virusIndex = Random.Range(0, unitList.Count);
        }
        string name = string.Format("Virus{0}", virusIndex);
        Debug.Log("spawning");
        Debug.Log(name);
        unitList[virusIndex].Spawn();
    }
}
