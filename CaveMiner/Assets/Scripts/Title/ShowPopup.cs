using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cave.Main.Title
{
    public class ShowPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popup;
        public void Show()
        {
            popup.SetActive(true);
        }
    }
}