using System;
using System.Collections;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{

    public class ConnectionStatus : MonoBehaviour
    {
        private string _lastConnectionStatus;

        private void Update()
        {
            var currentStatus = PhotonNetwork.NetworkClientState.ToString();
            
            if (currentStatus != _lastConnectionStatus)
            {
                Debug.Log($"Player network state changed: {currentStatus}");
            }
            _lastConnectionStatus = currentStatus;
        }
    }
}