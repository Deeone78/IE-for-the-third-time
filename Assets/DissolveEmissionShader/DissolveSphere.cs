using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour
{

    RaycastHit hit;
    public float range = 5f;
    Material mat;

    private void Start()
    {
        mat = GetComponent<Renderer>().material;

    }

    private void Update()
    {

        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        if (hit.collider.tag == ("NPC"))
        {
            mat.SetFloat("_DissolveAmount", Time.time * 0.2f);
            Debug.Log("you hit something");

        }
    }
}