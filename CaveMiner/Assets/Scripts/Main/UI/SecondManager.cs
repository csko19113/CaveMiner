using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Cave.Main.Shared;

namespace Cave.Main.UI
{
    public class SecondManager : MonoBehaviour
    {
        [SerializeField] private GameParam gameParam;
        [SerializeField] private Text limitText;
        private void Awake()
        {
            Debug.Log("SecondIn");
            gameParam.turnChangeCallBack += () => UpdateLimitSecond();
        }
        private void OnDestroy()
        {
            Debug.Log("Destroy");
            gameParam.turnChangeCallBack -= () => UpdateLimitSecond();
        }
        private void Update()
        {
            UpdateLimitSecond();
        }
        private void UpdateLimitSecond()
        {
            limitText.text = gameParam.second + " 秒";
        }
    }
}
