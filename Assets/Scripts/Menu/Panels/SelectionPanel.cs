using Photon.Pun;
using UnityEngine;

namespace Menu.Panels
{
    public class SelectionPanel : MonoBehaviourPunCallbacks
    {
        #region UI CALLBACKS

        public void OnCreateRoomButtonClicked()
        {
            PanelChanger.SetActive(PanelName.CreateRoom);
        }

        public void OnJoinRoomButtonClicked()
        {
            PanelChanger.SetActive(PanelName.JoinRoom);
        }

        public void OnRoomListButtonClicked()
        {
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }
            
            PanelChanger.SetActive(PanelName.RoomList);
        }
        
        #endregion
    }
}