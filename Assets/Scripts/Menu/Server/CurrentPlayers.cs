using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class CurrentPlayers : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Text _text;


        private void Update()
        {
            if (PhotonNetwork.InRoom)
            {
                _text.text = PhotonNetwork.CurrentRoom.Players.Count.ToString();
            }
            else
            {
                _text.text = "-1";
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            Debug.Log($"HOHOH {newPlayer.NickName} entered room");
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Debug.Log($"AHAHAH {otherPlayer.NickName} leave room");
        }
    }
}