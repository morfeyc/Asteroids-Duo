using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class RoomEntity : MonoBehaviour
    {
        [SerializeField] private Text RoomNameText;
        [SerializeField] private Button JoinRoomButton;

        private string _roomName;

        #region UNITY

        private void Start()
        {
            JoinRoomButton.onClick.AddListener(() =>
            {
                if (PhotonNetwork.InLobby)
                {
                    PhotonNetwork.LeaveLobby();
                }

                PhotonNetwork.JoinRoom(_roomName);
            });
        }

        #endregion

        public void Initialize(string name)
        {
            _roomName = name;
            
            RoomNameText.text = name;
        }
    }
}