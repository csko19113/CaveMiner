using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Cave.Common;
using Cave.Main.Shared;

public class ResultScoreManager : MonoBehaviour
{
    [SerializeField] private string scoreKey;
    [SerializeField] private Text nowScoreText;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        SaveDataManager saveDataManager = new SaveDataManager();
        nowScoreText.text = "Now score : " + GameManager.scoreList.Sum();
        highScoreText.text = "High score : " + saveDataManager.GetMaxScore(scoreKey);
        GameManager.scoreList.Clear();//スコアのリセット
    }
}
