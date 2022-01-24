using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Menu.Panels
{
    public enum PanelName
    {
        Login,
        Selection,
        CreateRoom,
        JoinRoom,
        RoomList,
        InsideRoom
    }
    
    public class PanelChanger : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject LoginPanel;
        [SerializeField] private GameObject SelectionPanel;
        [SerializeField] private GameObject CreateRoomPanel;
        [SerializeField] private GameObject JoinRoomPanel;
        [SerializeField] private GameObject RoomListPanel;
        [SerializeField] private GameObject InsideRoomPanel;

        private static Dictionary<PanelName, GameObject> _panels;
        private static PanelName _lastActivePanel = PanelName.Login;

        #region UNITY
        
        private void Awake()
        {
            _panels = new Dictionary<PanelName, GameObject>
            {
                {PanelName.Login, LoginPanel},
                {PanelName.Selection, SelectionPanel},
                {PanelName.CreateRoom, CreateRoomPanel},
                {PanelName.JoinRoom, JoinRoomPanel},
                {PanelName.RoomList, RoomListPanel},
                {PanelName.InsideRoom, InsideRoomPanel}
            };
        }
        
        #endregion

        #region UI CALLBACKS

        public void OnCancelButtonClicked()
        {
            SetActive(PanelName.Selection);
        }
        
        public void OnExitButtonClicked()
        {
            Application.Quit();
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnConnectedToMaster()
        {
            SetActive(PanelName.Selection);
        }
        
        public override void OnJoinedRoom()
        {
            SetActive(PanelName.InsideRoom);
        }

        public override void OnLeftRoom()
        {
            SetActive(PanelName.Selection);
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            SetActive(PanelName.Selection);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            SetActive(PanelName.Selection);
        }

        #endregion
        
        public static void SetActive(PanelName panelName)
        {
            if(_lastActivePanel == panelName) return;
            
            _panels[_lastActivePanel].SetActive(false);
            _panels[panelName].SetActive(true);

            _lastActivePanel = panelName;

        }
    }
}