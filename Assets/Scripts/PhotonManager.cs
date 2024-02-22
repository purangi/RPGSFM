using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI m_alertTxt;
    [SerializeField] TextMeshProUGUI m_textPlayerList;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;

        PhotonNetwork.LocalPlayer.NickName = GameManager.instance.name;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);
    }

    public override void OnJoinedRoom()
    {
        UpdatePlayer();
        m_alertTxt.text += PhotonNetwork.LocalPlayer.NickName + " 님이 방에 참가하였습니다.";
        StartCoroutine(ClearTxt());
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        UpdatePlayer();
        m_alertTxt.text = newPlayer.NickName + "님이 입장하였습니다.";
        StartCoroutine(ClearTxt());
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        UpdatePlayer();
        m_alertTxt.text = otherPlayer.NickName + "님이 퇴장하였습니다.";
        StartCoroutine(ClearTxt());
    }

    IEnumerator ClearTxt()
    {
        yield return new WaitForSeconds(2f);

        m_alertTxt.text = string.Empty;
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void UpdatePlayer()
    {
        for(int i = 0;i < PhotonNetwork.PlayerList.Length;i++)
        {
            m_textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
        }
    }
}
