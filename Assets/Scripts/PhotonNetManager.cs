using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetManager : Photon.MonoBehaviour {

    [SerializeField] GameObject mainCam;
    [SerializeField] GameObject hostPlayer;
    [SerializeField] GameObject clientPlayer;
    [SerializeField] Text msgText;

    [SerializeField] Button hostButton;
    [SerializeField] Button clientButton;

    private void Awake()
    {
        if (!PhotonNetwork.connected)
        {
            if (PhotonNetwork.ConnectUsingSettings("v1.0"))
            {
                Debug.Log("포톤에 접속 중...");
            }
            else
            {
                Debug.Log("포톤에 접속 실패");
            }

        }

    }

    private void OnEnable()
    {
        Application.logMessageReceived += LogMsgText;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= LogMsgText;
    }

    void Start()
    {

    }

    void JoinRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(
            "GameRoom",
            new RoomOptions()
            {
                MaxPlayers = 2,
                IsOpen = true,
                IsVisible = true
            },
            TypedLobby.Default
        );

    }

    private void LogMsgText(string condition, string stackTrace, LogType type)
    {
        msgText.text = condition + " " + stackTrace;
    }

    private void OnConnectedToServer()
    {
        
    }

    public void OnJoinedLobby()
    {
        Debug.Log("게임 로비에 접속이 완료됨");
        hostButton.interactable = true;
        clientButton.interactable = true;
    }

    public void OnJoinedRoom()
    {
        if (PhotonNetwork.isMasterClient)
        {
            clientPlayer.gameObject.SetActive(false);
        }
        else
        {
            hostPlayer.gameObject.SetActive(false);
        }
    }

    public void OnPhotonCreateRoomFailed(object[] errorMsg)
    {
        Debug.Log(errorMsg[1].ToString());
    }

    public void OnPhotonJoinRoomFailed(object[] errorMsg)
    {
        Debug.Log(errorMsg[1].ToString());
    }

    public void OnFailedToConnectToPhoton(DisconnectCause cause)
    {
        Debug.Log(cause.ToString());
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnHostButtonClick()
    {
        mainCam.gameObject.SetActive(false);
        hostButton.interactable = false;
        hostPlayer.gameObject.SetActive(true);
        PhotonNetwork.player.NickName = "Host";
        JoinRoom();
    }

    public void OnClientButtonClick()
    {
        mainCam.gameObject.SetActive(false);
        clientButton.interactable = false;
        clientPlayer.gameObject.SetActive(true);
        PhotonNetwork.player.NickName = "Client";
        clientPlayer.GetPhotonView().TransferOwnership(PhotonNetwork.player);
        JoinRoom();

    }

    public void OnGoToTitle()
    {
        mainCam.gameObject.SetActive(true);
        hostButton.interactable = true;
        clientButton.interactable = true;
        hostPlayer.SetActive(false);
    }

}
