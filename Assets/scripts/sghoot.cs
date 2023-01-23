using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sghoot : MonoBehaviour

{
   public GameObject CMFreeLook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            CMFreeLook.SetActive(false);
        }

        else if (Input.GetMouseButtonUp(0))
        {

            CMFreeLook.SetActive(true);

            //dust.Pause();
            //dust.Clear();
        }
    }
}
