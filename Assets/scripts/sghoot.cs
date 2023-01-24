using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sghoot : MonoBehaviour

{
    public GameObject camRot;
    //public GameObject CMFreeLook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




          if (Input.GetMouseButton(0))
        {

           // CMFreeLook.SetActive(false);
            transform.rotation = Quaternion.Euler(new Vector3(0f, camRot.transform.rotation.x, 0f));
        }

        else if (Input.GetMouseButtonUp(0))
        {

          //  CMFreeLook.SetActive(true);

            //dust.Pause();
            //dust.Clear();
        }
    }
}
