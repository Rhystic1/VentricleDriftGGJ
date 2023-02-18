using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    AudioDirector audioDirectorScript;
    // Start is called before the first frame update
    void Start()
    {
        audioDirectorScript = GameObject.FindGameObjectWithTag("EventSystem").GetComponent<AudioDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Walls") audioDirectorScript.ImpactWall();
        if (collision.gameObject.tag == "Enemy") audioDirectorScript.ImpactEnemy();
        if (collision.gameObject.tag == "Virus") audioDirectorScript.VirusDestroyed();
            
    }
}
