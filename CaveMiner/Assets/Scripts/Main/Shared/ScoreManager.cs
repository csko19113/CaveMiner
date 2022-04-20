using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cave.Main.Shared
{
    public class ScoreManager : MonoBehaviour
    {
        public UnityAction<int> wallBreakedCallback;
        private List<int> scoreList = new List<int>();
        private void Awake()
        {
            wallBreakedCallback += (score) => AddScore(score);
        }
        private void AddScore(int score)
        {
            scoreList.Add(score);
        }
        private void ResetScore()
        {
            scoreList = new List<int>();
        }
    }
}