using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool x;
    public ParticleSystem dust;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            dust.Play();
        }

        else if (Input.GetMouseButtonUp(0))
        {

            dust.Stop();

            //dust.Pause();
            //dust.Clear();
        }
    }
}
 