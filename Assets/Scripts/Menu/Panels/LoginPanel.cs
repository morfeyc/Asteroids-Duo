using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Panels
{
    public class LoginPanel : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField UsernameInput;

        #region UI CALLBACKS

        public void OnLoginButtonClicked()
        {
            string playerUsername = UsernameInput.text;
            
            if (playerUsername.Length > 0)
            {
                PhotonNetwork.LocalPlayer.NickName = playerUsername;
                PhotonNetwork.ConnectUsingSettings();
            }
            else
            {
                // show err;
            }
        }

        #endregion
    }
}