using System;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Menu.Panels
{
    public class RoomListPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject RoomListContent;
        [SerializeField] private GameObject RoomListRoomPrefab;
        
        private Dictionary<string, RoomInfo> _cachedRoomList;
        private Dictionary<string, GameObject> _roomListEntries;

        #region UNITY

        private void Awake()
        {
            _cachedRoomList = new Dictionary<string, RoomInfo>();
            _roomListEntries = new Dictionary<string, GameObject>();
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnJoinedRoom()
        {
            _cachedRoomList.Clear();
        }
        
        public override void OnJoinedLobby()
        {
            _cachedRoomList.Clear();
            ClearRoomListView();
        }
        
        public override void OnLeftLobby()
        {
            _cachedRoomList.Clear();
            ClearRoomListView();
        }
        
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            ClearRoomListView();
            
            UpdateCachedRoomList(roomList);
            UpdateRoomListView();
        }

        #endregion
        
        private void ClearRoomListView()
        {
            foreach (var roomEntity in _roomListEntries.Values)
            {
                Destroy(roomEntity.gameObject);
            }
            
            _roomListEntries.Clear();
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
            foreach (var roomInfo in roomList)
            {
                if (!roomInfo.IsOpen || !roomInfo.IsVisible || roomInfo.RemovedFromList)
                {
                    if (_cachedRoomList.ContainsKey(roomInfo.Name))
                    {
                        _cachedRoomList.Remove(roomInfo.Name);
                    }
                    
                    continue;
                }

                if (_cachedRoomList.ContainsKey(roomInfo.Name))
                {
                    _cachedRoomList[roomInfo.Name] = roomInfo;
                }
                else
                {
                    _cachedRoomList.Add(roomInfo.Name, roomInfo);
                }
            }
        }

        private void UpdateRoomListView()
        {
            foreach (var roomInfo in _cachedRoomList.Values)
            {
                var roomEntity = Instantiate(RoomListRoomPrefab);
                roomEntity.transform.SetParent(RoomListContent.transform);
                roomEntity.transform.localScale = Vector3.one;
                roomEntity.GetComponent<RoomEntity>().Initialize(roomInfo.Name);
                
                _roomListEntries.Add(roomInfo.Name, roomEntity);
            }
        }
    }
}