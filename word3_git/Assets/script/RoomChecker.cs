using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomChecker : MonoBehaviour
{
    public static int numberMember = 1;
    public static string name0 ="";
    public  string name0_douki = "";
    public static string name1 ="";
    public string name1_douki = "";
    public static string name2="";
    public string name2_douki = "";
    public static string name3="";
    public string name3_douki = "";



    [SerializeField]
    Text RoomText;
    Text joinedMembersText;

    // Start is called before the first frame update
    void Start()
    {
      
        string ShowMyName = PM2.getMyNameAll();//入力した名前
        if (ShowMyName == "")
        {
            PhotonNetwork.playerName = "guest" + PhotonNetwork.player.ID;
        }else{
            PhotonNetwork.playerName = ShowMyName;
        }
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        GameObject.Find("roomNumber").GetComponent<Text>().text = "";

        //PhotonNetwork.playerName = "guest" + UnityEngine.Random.Range(1000, 9999);
       
    }

        // Update is called once per frame
        void Update()
        {
        UpdateMemberList();
        }


    void OnJoinedLobby()
    {
        Debug.Log("PhotonManager OnJoinedLobby");
        //ボタンを押せるようにする
      //  GameObject.Find("CreateRoomB").GetComponent<Button>().interactable = true;

    }

    //ルーム一覧が取れると
    void OnReceivedRoomListUpdate()
    {
        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0)
        {
            Debug.Log("ルームが一つもありません");
        }
        else
        {
            //ルームが1件以上ある時ループでRoomInfo情報をログ出力
            for (int i = 0; i < rooms.Length; i++)
            {
                Debug.Log("RoomName:" + rooms[i].name);
                Debug.Log("userName:" + rooms[i].customProperties["userName"]);
                Debug.Log("userId:" + rooms[i].customProperties["userId"]);
              
             
                //     GameObject.Find("Room").GetComponent<Text>().text = rooms[i].name+"\n";
            }
        }
    }


    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        Debug.Log(player.name + " is joined.");
        UpdateMemberList();
    }

    // <summary>
    // リモートプレイヤーが退室した際にコールされる
    // </summary>
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        Debug.Log(player.name + " is left.");
        UpdateMemberList();
    }

    public void UpdateMemberList()//メンバーリストの取得と表示
    {
        GameObject.Find("Room").GetComponent<Text>().text = "";
        GameObject.Find("Room").GetComponent<Text>().text += "Member:" + "\n";
        // joinedMembersText.text = "";
        name0 = "";
        name1 = "";
        name2 = "";
        name3 = "";
        foreach (var p in PhotonNetwork.playerList)
        {
           
            GameObject.Find("Room").GetComponent<Text>().text += p.name ;
            if (name0 == "")//要直す
            {
                //name0_douki = p.name;
                name0 = p.name;
                numberMember = 1;
            }
            else if (name1 == "" && p.name != name0)
            {
                //name1_douki = p.name;
                name1 = p.name;
                numberMember = 2;
            }
            else if (name2 == "" && p.name != name0 && p.name != name1)
            {
                //name2_douki = p.name;
                name2 = p.name;
                numberMember = 3;
            }
            else if (name3 == "" && p.name != name0 && p.name != name1 && p.name != name2)
            {
                //name3_douki = p.name;
                name3 = p.name;
                numberMember = 4;
                     }
            Debug.Log(numberMember);
        }
    }

    public static int getnumberMember()
    {
        return numberMember;
    }

    public static string getName0()
    {
        //  get{ return this.name0; }
        //  set { this.name0 = value; }
        return name0;

    }

    public static string getName1()
    {
        //   get{ return this.name1; }
        //   set { this.name1 = value; }
        return name1;
    }

    public static string getName2()
    {
      //  get{ return this.name2; }
      //  set { this.name2 = value; }
         return name2;
    }

    public static string getName3()
    {
     //   get{ return this.name3; }
     //   set { this.name3 = value; }
         return name3;
    }
 
}

