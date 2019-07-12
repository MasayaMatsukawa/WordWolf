using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowResult : MonoBehaviour
{
    public string name0;
    public string name1;
    public string name2;
    public string name3;
    public int bCount;
    public int NowMember;
    public int pID;
    public string[] words = { "猫", "犬", "犬", "犬" };

    [SerializeField]
    Text joinedMembersText1;

    [SerializeField]
    Text joinedMembersText2;

    [SerializeField]
    Text joinedMembersText3;

    [SerializeField]
    Text joinedMembersText4;
    // Start is called before the first frame update

    //public RoomChecker roomChecker;

    void Start()
    {
       
        bCount = RoomChecker.getnumberMember();
         NowMember = bCount;
         pID = PhotonNetwork.player.ID;

        name0 = RoomChecker.getName0();
        name1 = RoomChecker.getName1();
        name2 = RoomChecker.getName2();
        name3 = RoomChecker.getName3();
        if (pID == 1)
        {
            joinedMembersText1.text = name0 ;
            joinedMembersText2.text = name1 ;
            joinedMembersText3.text = name2;
            joinedMembersText4.text = name3 ;
         
        }
        else if(pID ==2){
            joinedMembersText1.text = name1 ;
            joinedMembersText2.text = name0 ;
            joinedMembersText3.text = name2 ;
            joinedMembersText4.text = name3 ;
      
        }
        else if (pID == 3)
        {
            joinedMembersText1.text = name1;
            joinedMembersText2.text = name2 ;
            joinedMembersText3.text = name0 ;
            joinedMembersText4.text = name3 ;
       
        }
        else if (pID == 4)
        {
            joinedMembersText1.text = name1 ;
            joinedMembersText2.text = name2 ;
            joinedMembersText3.text = name3 ;
            joinedMembersText4.text = name0 ;
       
        }

        for (int i = 0; i < bCount; i++)
        {
            switch (i)
            {
                case 0:
                    GameObject.Find("WordText2").GetComponent<Text>().text = words[0] ;
                    break;
                case 1:
                    GameObject.Find("WordText21").GetComponent<Text>().text = words[1] ;
                    break;
                case 2:
                    GameObject.Find("WordText22").GetComponent<Text>().text = words[1] ;
                    break;
                case 4:
                    GameObject.Find("WordText23").GetComponent<Text>().text = words[1];
                    break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
       
  

    }

    void OnJoinedRoom()
    {
        // Roomに参加しているプレイヤー情報を配列で取得.
        PhotonPlayer[] player = PhotonNetwork.playerList;

        // プレイヤー名とIDを表示.
        for (int i = 0; i < player.Length; i++)
        {
            Debug.Log((i).ToString() + " : " + player[i].name + " ID = " + player[i].ID);
        }

    }

    /*
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
    {
     //データの送信
     stream.SendNext(name0);
     stream.SendNext(name1);
     stream.SendNext(name2);
     stream.SendNext(name3);
    }
    else
    {
     //データの受信
        this.name0 = (string)stream.ReceiveNext();    
        this.name1 = (string)stream.ReceiveNext();    
        this.name2 = (string)stream.ReceiveNext();
        this.name3 = (string)stream.ReceiveNext();

}
}*/
}
