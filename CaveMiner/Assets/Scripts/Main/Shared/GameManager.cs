using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Cave.Main.Board;
using Cave.Main.Chara;
using Cave.Main.Enemy;
using Cave.Common;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Shared
{
    public class GameManager : SceneController
    {
        public static GameManager instance;
        public static List<int> scoreList = new List<int>();
        public static bool isMoving;//任意のオブジェクトが動いているか
        public event UnityAction<int> enemyMoveAction;
        public UnityAction goalCallback;
        public List<EnemyController> enemies = new List<EnemyController>();
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private GameParam gameParam;
        [SerializeField] private string scoreKey;
        private SaveDataManager saveDataManager = new SaveDataManager();
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
            gameParam.ResetSecond();
            playerTurn = gameParam.playerTurn;
            isMoving = false;

            boardManager = GameObject.FindGameObjectWithTag("BoardManager").GetComponent<BoardManager>();
            boardManager.Create();
        }
        private async void Update()
        {
            GameOverCheck();
            if (isMoving) return;
            if (!gameParam.playerTurn)
            {
                enemies.ForEach(n => n.EnemyMove(gameParam.second));
                if (enemies.Select(n => n.IsMoving).All(n => !n))
                {
                    await UniTask.Delay(250);
                    gameParam.playerTurn = true;
                    return;
                }
            }
        }
        private void GameOverCheck()
        {
            if (gameParam.second <= 0)
            {
                if (scoreList.Sum() >= saveDataManager.GetMaxScore(scoreKey))
                {
                    saveDataManager.SetMaxScore(scoreKey, scoreList.Sum());
                }
                gameParam.ResetSecond();
                base.SceneChange(base.scenename.ToString());
                Debug.Log("GameOver");
            }
        }
        /*
        private void UpdateLimitSecond()
        {
            limitText.text = gameParam.second + " 秒";
        }
        */
    }
}