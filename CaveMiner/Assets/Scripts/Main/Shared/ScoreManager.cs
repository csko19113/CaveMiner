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
        private List<int> scoreList = new List<int>();//ToDo scoreの持越しが出来てない
        [SerializeField] private Text scoreText;
        private void Awake()
        {
            wallBreakedCallback += (score) => { scoreList.Add(score); };
            wallBreakedCallback += (score) =>
            {
                scoreText.text = " $:" + scoreList.Sum();
            };
        }
        private void ResetScore()
        {
            scoreList = new List<int>();
        }
    }
}