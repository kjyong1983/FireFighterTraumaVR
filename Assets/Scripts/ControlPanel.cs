using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : Photon.MonoBehaviour {

    [SerializeField] Light light;
    [SerializeField] Slider slider;
    [SerializeField] GameObject testPrefab;
    PhotonNetManager netManager;

    private void Awake()
    {
        netManager = FindObjectOfType<PhotonNetManager>();

        if (!PhotonNetwork.connected)
        {
            Debug.Log("포톤 네트워크 서버와 연결이 끊어짐");
            return;
        }

    }

    private void OnEnable()
    {
        //photonView.TransferOwnership()
        //PhotonNetwork.SetMasterClient(PhotonNetwork.player);


    }

    public void OnLightOnButtonClick()
    {
        photonView.RPC("TurnLightOn", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    public void TurnLightOn()
    {
        light.enabled = true;
    }

    public void OnLightOffButtonClick()
    {
        photonView.RPC("TurnLightOff", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    public void TurnLightOff()
    {
        light.enabled = false;
    }

    public void OnSliderValueChanged()
    {
        photonView.RPC("ChangeLightIntensity", PhotonTargets.AllViaServer, slider.value * 30);
    }

    [PunRPC]
    public void ChangeLightIntensity(float value)
    {
        light.enabled = true;
        light.intensity = value;
    }

    public void OnTestButtonClick()
    {
        photonView.RPC("SpawnObject", PhotonTargets.AllViaServer);
    }

    [PunRPC]
    public void SpawnObject()
    {
        Instantiate(testPrefab, new Vector3(0, 3, 0), Quaternion.identity);
    }

    public void OnTitleButtonClick()// 클라이언트를 강퇴한다 - 잘안됨.
    {
        ResetAllProgress();
    }

    private void ResetAllProgress()
    {
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            if (PhotonNetwork.playerList[i] != PhotonNetwork.player)
            {
                PhotonNetwork.CloseConnection(PhotonNetwork.playerList[i]);
            }

        }
        PhotonNetwork.LeaveRoom();
        netManager.OnGoToTitle();

    }

}
