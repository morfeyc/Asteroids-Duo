using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Menu
{
    public class OnButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Text TextBox;
        
        [SerializeField] private Color32 NormalColor = Color.white;
        [SerializeField] private Color32 OnHoverColor = Color.white;

        [SerializeField] private FontStyle NormalStyle;
        [SerializeField] private FontStyle OnHoverStyle;

        public void OnPointerEnter(PointerEventData eventData)
        {
            TextBox.color = OnHoverColor;
            TextBox.fontStyle = OnHoverStyle;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            TextBox.color = NormalColor;
            TextBox.fontStyle = NormalStyle;
        }

        private void OnDisable()
        {
            TextBox.color = NormalColor;
            TextBox.fontStyle = NormalStyle;
        }
    }
}