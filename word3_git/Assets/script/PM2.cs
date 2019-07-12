using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PM2 : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField MyName;
    public Text myname;
    public string roomName = "room1";

    public static string MyNameAll="";
    void Start()
    {
        //if (MyNameAll = "")
       // {
            GameObject.Find("StatusText1").GetComponent<Text>().text = "";
            MyName = MyName.GetComponent<InputField>();
            // myname = text.GetComponent<Text>();
            PhotonNetwork.ConnectUsingSettings("v1.0");
       // }else{
       //     MyName = MyName.GetComponent<InputField>();
       // }
        // PhotonNetwork.CreateRoom(roomName);

    }


    // public object PhotonNetwork { get; private set; }
    public void CreateRoom()
    {
        string userName = "ユーザ1";
        string userId = "user1";
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("userName", userName); //ユーザ名
        customProp.Add("userId", userId); //ユーザID
        PhotonNetwork.SetPlayerCustomProperties(customProp);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.customRoomProperties = customProp;
        //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.customRoomPropertiesForLobby = new string[] { "userName", "userId" };
        roomOptions.maxPlayers = 4; //部屋の最大人数
        roomOptions.isOpen = true; //入室許可する
        roomOptions.isVisible = true; //ロビーから見えるようにする
        //userIdが名前のルームがなければ作って入室、あれば普通に入室する。
        PhotonNetwork.JoinOrCreateRoom("room1", roomOptions, null); //userIDの部屋
        //GameObject.Find("StatusText1").GetComponent<Text>().text += "roomが作成されました";
    }

    public void PushPlay()//ルームを作成する
    {
        // PhotonNetwork.JoinRandomRoom();
       // PhotonNetwork.JoinRoom("user1");
        CreateRoom();
        Debug.Log("ルーム"  + "sakusei");
        MyNameAll = MyName.text;
    }

    void OnJoinedRoom()
    {
        Debug.Log("PhotonManager OnJoinedRoom");
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(roomName);
        Debug.Log("ルーム入室に失敗したのでルームを作成します");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return"))
        {
            GameObject.Find("Myname").GetComponent<Text>().text = "ユーザーネーム:" + MyName.text;
        }
    }

    void OnReceivedRoomListUpdate()
    {
        //ルーム一覧を取る
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();
        if (rooms.Length == 0)
        {
            GameObject.Find("StatusText1").GetComponent<Text>().text = "部屋名[room1]  0 / 4";
        }
        else
        {
           
            //ルームが1件以上ある時ループでRoomInfo情報をログ出力
            for (int i = 0; i < rooms.Length; i++)
            {
                Debug.Log("RoomName:" + rooms[i].name);
                Debug.Log("userName:" + rooms[i].customProperties["userName"]);
                Debug.Log("userId:" + rooms[i].customProperties["userId"]);
              //  GameObject.Find("room").GetComponent<Text>().text = rooms[i].name;
                GameObject.Find("StatusText1").GetComponent<Text>().text = "roomがあります";
                GameObject.Find("StatusText1").GetComponent<Text>().text = "部屋名["+rooms[i].name +"]   " +rooms[i].playerCount+"/"+ rooms[i].maxPlayers;
            }
        }
    }

    void OnJoinedLobby()
    {
        Debug.Log("PhotonManager OnJoinedLobby");
        //ボタンを押せるようにする
        // GameObject.Find("CreateRoomB").GetComponent<Button>().interactable = true;
      //  RoomInfo[] rooms = PhotonNetwork.GetRoomList();
      //  GameObject.Find("room").GetComponent<Text>().text += rooms[0].name;
    }


    public static string getMyNameAll()
    {
        return MyNameAll;
    }
}