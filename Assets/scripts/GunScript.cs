using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    GameObject campos3;

    // Start is called before the first frame update
    void Start()
    {
        campos3 = GameObject.Find("CamPos3");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = campos3.transform.position - transform.position;
        Quaternion newRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = newRotation;
    }
}
