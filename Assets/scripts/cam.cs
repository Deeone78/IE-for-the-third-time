
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public GameObject player;
    public GameObject movePosition;
    public GameObject shootPosition;
    public float moveSpeed = 3f;
    public float rotationSpeed = 3f;
    public GameObject target;
    void Start() 
    {
       
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 targetDirection = target.transform.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            transform.position = Vector3.Lerp(transform.position, shootPosition.transform.position, Time.deltaTime * moveSpeed);

        } else
        {
            Vector3 targetDirection = player.transform.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotationSpeed);
            transform.position = Vector3.Lerp(transform.position, movePosition.transform.position, Time.deltaTime * moveSpeed);
        }

      //  else if (Input.GetMouseButtonUp(0))
      //  {
        //    transform.position = Vector3.Lerp(transform.position, movePosition.transform.position, Time.deltaTime * 3);

    //    }

    }
}
