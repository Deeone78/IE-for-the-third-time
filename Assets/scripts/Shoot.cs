using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool x;
    public ParticleSystem dust;
    public GameObject mainCam;
    public GameObject aimcam;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mainCam.SetActive(false);
            aimcam.SetActive(true);

            dust.Play();
        }

        else if (Input.GetMouseButtonUp(0))
        {

            dust.Stop();
            mainCam.SetActive(true);
            aimcam.SetActive(false);
            //dust.Pause();
            //dust.Clear();
        }
    }
}
 