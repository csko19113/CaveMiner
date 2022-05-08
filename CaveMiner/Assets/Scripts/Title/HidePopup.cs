using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    public void Hide()
    {
        popup.SetActive(false);
    }
}
