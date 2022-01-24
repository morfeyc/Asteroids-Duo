using System;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Panels
{
    public class InsideRoomPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject StartGameButton;
        [SerializeField] private Text RoomNameText;
        [SerializeField] private Text RoomAccessText;
        [SerializeField] private Text FirstPlayerUsernameText;
        [SerializeField] private Text SecondPlayerUsernameText;
        [SerializeField] private GameObject WaitingImg;

        #region UNITY

        public override void OnEnable()
        {
            RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
            RoomAccessText.text = PhotonNetwork.CurrentRoom.IsVisible ? "PUBLIC" : "PRIVATE";

            ClearPlayersView();
            UpdatePlayersView();
        }

        public override void OnDisable()
        {
            Debug.Log("Inside Room Panel Disabled");
        }

        #endregion
        
        #region UI CALLBACKS

        public void OnLeaveRoomButtonClicked()
        {
            PhotonNetwork.LeaveRoom();
        }

        public void OnStartGameButtonClicked()
        {
            PhotonNetwork.LoadLevel("Game");
        }

        #endregion
        
        #region PUN CALLBACKS

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            ClearPlayersView();
            UpdatePlayersView();
            Debug.Log($"{newPlayer.NickName} joined room");
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            ClearPlayersView();
            UpdatePlayersView();
            Debug.Log($"{otherPlayer.NickName} leave room");
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            ClearPlayersView();
            UpdatePlayersView();
        }

        #endregion

        private void ClearPlayersView()
        {
            FirstPlayerUsernameText.text = string.Empty;
            SecondPlayerUsernameText.text = string.Empty;   
        }
        
        private void UpdatePlayersView()
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if (player.IsMasterClient)
                {
                    FirstPlayerUsernameText.text = player.NickName;
                }
                else
                {
                    SecondPlayerUsernameText.text = player.NickName;
                }
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    StartGameButton.SetActive(true);
                }
                WaitingImg.SetActive(false);
            }
            else
            {
                StartGameButton.SetActive(false);
                WaitingImg.SetActive(true);
            }
        }
    }
}