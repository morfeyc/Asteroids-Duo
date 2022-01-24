using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Panels
{
    public class CreateRoomPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField CreateRoomNameInput;
        [SerializeField] private Toggle AccessToggle;
        [SerializeField] private Text AccessToggleLabel;

        private bool _isVisible = true;

        #region UNITY

        public override void OnEnable()
        {
            AccessToggle.isOn = true;
            CreateRoomNameInput.text = string.Empty;
        }

        #endregion
        
        #region UI CALLBACK

        public void OnAccessToggleClicked()
        {
            _isVisible = !_isVisible;
            AccessToggleLabel.text = _isVisible ? "PUBLIC" : "PRIVATE";
        }
        
        public void OnCreateRoomButtonClicked()
        {
            string roomName = CreateRoomNameInput.text;
            const byte maxPlayers = 2;

            var options = new RoomOptions
            {
                MaxPlayers = maxPlayers,
                PlayerTtl = 10000,
                IsVisible = true
            };
            
            PhotonNetwork.CreateRoom(roomName, options, null);
        }

        #endregion
    }
}