using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class wordGive : MonoBehaviour
{

    void Start()
    {
        int pID = PhotonNetwork.player.ID;
        string[] words={"猫","犬"};
        //pID = RoomChecker.getnumberMember();
  
            if (pID == 1)
            {
                GameObject.Find("WordText").GetComponent<Text>().text = words[0];
        }else{
            GameObject.Find("WordText").GetComponent<Text>().text = words[1];
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
