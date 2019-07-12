using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomMember : MonoBehaviour
{
    [SerializeField]
    Text joinedMembersText;

    // Start is called before the first frame update
    void Start()
    {

        UpdateMemberList();
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        Debug.Log(player.name + " is joined.");
        UpdateMemberList();
    }

   
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        Debug.Log(player.name + " is left.");
        UpdateMemberList();
    }

    public void UpdateMemberList()
    {
        joinedMembersText.text = "";
        Debug.Log(PhotonNetwork.playerName + " is joined.");
        foreach (var p in PhotonNetwork.playerList)
        {
            joinedMembersText.text += p.name + "\n";
        }
    }
}

