using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    PhotonView photonView;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toRomeScene()
    {
    //    PhotonNetwork.playerName = GameObject.Find("MyName").GetComponent<Text>().text ;
        SceneManager.LoadScene("room");
    }

    public void toGameScene2()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void toPlayScene()
    {

     
       photonView.RPC("RPCtoPlayScene", PhotonTargets.All);
        if (i == 1)
       {
            SceneManager.LoadScene("GamePlay");
        }
    }

    public void toMatching()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Matching");
    }

    public void toVote()
    {
        photonView.RPC("RPCtoVote", PhotonTargets.All);

      //  SceneManager.LoadScene("Vote");
    }


    [PunRPC]
    void RPCtoPlayScene()
    {
        i= 1;
        SceneManager.LoadScene("GamePlay");
    }

    [PunRPC]
    void RPCtoVote()
    {
        SceneManager.LoadScene("Vote");
    }
}
