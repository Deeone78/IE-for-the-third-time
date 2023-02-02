using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dButton1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartButton1;
    
    void Start()
    {
        Button btn1 = StartButton1.GetComponent<Button>();
    }

    // Update is called once per frame


    public void TaskOnClick()
    {

        SceneManager.LoadScene(2) ;

    }
    
    void Update()
    {
        
    }
}
