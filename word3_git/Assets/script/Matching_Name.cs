using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matching_Name : MonoBehaviour
{
    public Image name;
    public GameObject NameObject;
    // Start is called before the first frame update
    void Start()
    {
        //string ShowMyName = PM2.getMyNameAll();
        //if (ShowMyName != ""){
       //     Debug.Log(ShowMyName);
           //d NameObject.SetActive(false);
      //  }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return")){
            NameObject.SetActive(false);
        }
    }

    public void Enter()
    {
        if (Input.GetKey("enter"))
        {
            NameObject.SetActive(false);
        }
    }


}
