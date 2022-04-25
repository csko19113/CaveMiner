using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cave.Main.Board;
using Cave.Main.Chara;
using Cave.Main.Enemy;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Shared
{
    public class GameManager : SceneController
    {
        public static GameManager instance;
        public static bool isMoving;//任意のオブジェクトが動いているか
        public event UnityAction<int> enemyMoveAction;
        public UnityAction goalCallback;
        public List<EnemyController> enemies = new List<EnemyController>();
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private GameParam gameParam;
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

            boardManager.Create();
        }
        private void Update()
        {
            GameOverCheck();
            if (isMoving) return;
            if (gameParam.playerTurn != true)
            {
                enemies.ForEach(n => n.EnemyMove(gameParam.second));
                gameParam.playerTurn = true;
                return;
            }
        }
        private void GameOverCheck()
        {
            if (gameParam.second <= 0)
            {
                base.SceneChange(base.scenename.ToString());
                Debug.Log("GameOver");
            }
        }
    }
}