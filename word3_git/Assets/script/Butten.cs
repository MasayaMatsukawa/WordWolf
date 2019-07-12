using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Butten : MonoBehaviour
{

// 対象のオブジェクト群（エディタでセットできたと思います）
    
    public Button[] buttons;
    public Button button;
    void Start()
    {
       
      

    }

    public void OneClick()
    {

        foreach (var t in buttons)
        {
            button = t;
            button.interactable = false;
        }
    }
}
