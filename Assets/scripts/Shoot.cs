using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool x;
    public ParticleSystem dust;
    public GameObject mainCam;
    public GameObject aimcam;
    float m_FieldOfView;
    void Start()
    {
        m_FieldOfView = 60.0f;
    }


    void Update()
    {

        Camera.main.fieldOfView = m_FieldOfView;

        if (Input.GetMouseButtonDown(0))
        {

            float max, min;
            max = 150.0f;
            min = 40.0f;
            //mainCam.SetActive(false);
            //aimcam.SetActive(true);
           
            dust.Play();
        }

        else if (Input.GetMouseButtonUp(0))
        {

            dust.Stop();
            //mainCam.SetActive(true);
            //aimcam.SetActive(false);
            //dust.Pause();
            //dust.Clear();
        }
    }
}
 