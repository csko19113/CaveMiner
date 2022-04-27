using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Cave.Main.Shared
{
    public class ScoreManager : MonoBehaviour
    {
        public UnityAction<int> wallBreakedCallback;
        public static List<int> scoreList = new List<int>();//ToDo scoreの持越しが出来てない
        [SerializeField] private Text scoreText;
        private void Awake()
        {
            wallBreakedCallback += (score) => { if (score != 0) scoreList.Add(score); };
            wallBreakedCallback += (score) =>
            {
                scoreText.text = " $:" + scoreList.Sum();
            };
            wallBreakedCallback.Invoke(0);//textの反映
        }
        private void ResetScore()
        {
            scoreList.Clear();
        }
    }
}