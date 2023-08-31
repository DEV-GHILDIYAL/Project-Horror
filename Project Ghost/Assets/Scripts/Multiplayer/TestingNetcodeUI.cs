using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class TestingNetcodeUI : NetworkBehaviour
{
    [SerializeField] Button startHostButton;
    [SerializeField] GameObject mainPanel;
    [SerializeField] Button startClientButton;
    [SerializeField] TextMeshProUGUI playerCountText;

    NetworkVariable<int> playersNum = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone);

    private void Awake()
    {
        startHostButton.onClick.AddListener(() =>
        {
            Debug.Log("Host");
            NetworkManager.Singleton.StartHost();
            Hide();
        });

        startClientButton.onClick.AddListener(() =>
        {
            Debug.Log("Client");
            NetworkManager.Singleton.StartClient();
            
            Hide();
        });
    }
    void Hide()
    {
       mainPanel.SetActive(false);
    }

    private void Update()
    {
        playerCountText.text = "Player : " + playersNum.Value.ToString();

        if (!IsServer) return;
        playersNum.Value = NetworkManager.Singleton.ConnectedClients.Count;
    }
}
