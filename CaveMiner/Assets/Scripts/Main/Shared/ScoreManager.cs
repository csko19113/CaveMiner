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
        [SerializeField] private Text scoreText;
        private void Awake()
        {
            wallBreakedCallback += (score) => { if (score != 0) GameManager.scoreList.Add(score); };
            wallBreakedCallback += (score) =>
            {
                scoreText.text = " $:" + GameManager.scoreList.Sum();
            };
            wallBreakedCallback.Invoke(0);//textの反映
        }
    }
}