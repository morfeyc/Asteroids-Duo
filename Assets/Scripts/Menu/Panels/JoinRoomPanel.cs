using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Panels
{
    public class JoinRoomPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField JoinRoomNameInput;

        #region UNITY

        public override void OnEnable()
        {
            JoinRoomNameInput.text = string.Empty;
        }

        #endregion
        
        #region UI CALLBACKS

        public void OnJoinRoomButtonClicked()
        {
            PhotonNetwork.JoinRoom(JoinRoomNameInput.text);
            
        }

        #endregion
    }
}