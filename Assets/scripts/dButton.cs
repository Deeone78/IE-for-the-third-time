using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class dButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartButton;
    
    void Start()
    {
        Button btn = StartButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void TaskOnClick()
    {

        SceneManager.LoadScene(1) ;

    }
    
    void Update()
    {
        
    }
}
