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
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;
        public static bool isMoving;//任意のオブジェクトが動いているか
        public event UnityAction<int> enemyMoveAction;
        public List<EnemyController> enemies = new List<EnemyController>();
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private CharaController charaController;
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
            charaController = GameObject.FindWithTag("Player").GetComponent<CharaController>();
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

            charaController.PlayerMove();

        }
        private void GameOverCheck()
        {
            if (gameParam.second <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }
}