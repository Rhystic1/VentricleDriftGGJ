using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnim : MonoBehaviour
{
    private Animator anim;

    [Range(-1f, 1f)]
    public float slider = 0;

    private void Awake()
    {
        anim= GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetFloat("Turning", slider);
    }
}
