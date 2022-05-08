using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    public void Show()
    {
        popup.SetActive(true);
    }
}
