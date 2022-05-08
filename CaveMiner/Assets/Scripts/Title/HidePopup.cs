using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cave.Main.Title
{
    public class HidePopup : MonoBehaviour
    {
        [SerializeField] private GameObject popup;
        public void Hide()
        {
            popup.SetActive(false);
        }
    }
}