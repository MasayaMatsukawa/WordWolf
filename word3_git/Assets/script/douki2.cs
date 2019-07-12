using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class douki2 : MonoBehaviour
{
    public int user1 = 0;
    public int user2 = 0;
    public int user3 = 0;
    public int user4 = 0;
    public int myVote = 0;
    public int myID ;
    // Start is called before the first frame update
    int pID = PhotonNetwork.player.ID;

    [SerializeField]
    Text Text;
    Text Nowpeople;

    PhotonView photonView;

    private object guestname;

    public GameObject hide;
    void Start()
    {
     
        photonView = GetComponent<PhotonView>();
        myID = pID;
     
              GameObject.Find("user1Butten").GetComponent<Text>().text = "投票する"+user1.ToString();
              GameObject.Find("user2Butten").GetComponent<Text>().text = "投票する"+user2.ToString();
              GameObject.Find("user3Butten").GetComponent<Text>().text = "投票する"+user3.ToString();
              GameObject.Find("user4Butten").GetComponent<Text>().text = "投票する"+user4.ToString();
   
    }

    // Update is called once per frame
    void Update()
    {
        int bCount;
        bCount = RoomChecker.getnumberMember();
        GameObject.Find("user1Butten").GetComponent<Text>().text = "投票する 現在:"+user1.ToString()+"票";
            GameObject.Find("user2Butten").GetComponent<Text>().text = "投票する 現在:" + user2.ToString() + "票";
            GameObject.Find("user3Butten").GetComponent<Text>().text = "投票する 現在:" + user3.ToString() + "票";
            GameObject.Find("user4Butten").GetComponent<Text>().text = "投票する 現在:" + user4.ToString() + "票";

        GameObject.Find("NowPeople").GetComponent<Text>().text = myVote-1 +"/"+ bCount +"投票しています";
        if(myVote -1 == bCount){
            hide.SetActive(false);
            PhotonNetwork.LeaveRoom();
          //  PhotonNetwork.Disconnect();
        }
    }

    public void VoteUser1()
    {

            photonView.RPC("RPCUser1", PhotonTargets.All);
        photonView.RPC("RPCVoteCount", PhotonTargets.All);

        //  myVote = 0;
    }

    public void VoteUser2()
    {
  
            photonView.RPC("RPCUser2", PhotonTargets.All);
        photonView.RPC("RPCVoteCount", PhotonTargets.All);
        // myVote = 0;
    }

    public void VoteUser3()
    {
  
            photonView.RPC("RPCUser3", PhotonTargets.All);
        photonView.RPC("RPCVoteCount", PhotonTargets.All);
        //  myVote = 0;
    }

    public void VoteUser4()
    {
            photonView.RPC("RPCUser4", PhotonTargets.All);
        //  myVote = 0;
        photonView.RPC("RPCVoteCount", PhotonTargets.All);
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) //マスターの変数のみ反映される
    {
        if (stream.isWriting)
        {
         //   if (!PhotonNetwork.isMasterClient)
         //   {
                //データの送信
              //  stream.SendNext(user1);
             //  stream.SendNext(user2);
             //   stream.SendNext(user3);
               // stream.SendNext(user4);
           }
            else
            {
                //データの受信
             //   this.user1 = (int)stream.ReceiveNext();
             //   this.user2 = (int)stream.ReceiveNext();
             //   this.user3 = (int)stream.ReceiveNext();
             //  this.user4 = (int)stream.ReceiveNext();
            }



       // }
    }

        [PunRPC]
    void RPCUser4()
    {
        user4+=1;
    }

    [PunRPC]
    void RPCUser3()
    {
        user3 += 1;
    }

    [PunRPC]
    void RPCUser2()
    {
        user2 += 1;
    }

    [PunRPC]
    void RPCUser1()
    {
        user1 += 1;
    }

    [PunRPC]
    void RPCVoteCount()
    {
        myVote += 1;
    }
}
