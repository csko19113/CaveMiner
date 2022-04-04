using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Board;
using Cave.Main.Chara;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Shared
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;
        public static bool isMoving;//任意のオブジェクトが動いているか
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private CharaController charaController;
        [SerializeField] private int second;
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
            second = gameParam.second;
            playerTurn = gameParam.playerTurn;
            isMoving = false;

            boardManager.Create();
            charaController = GameObject.FindWithTag("Player").GetComponent<CharaController>();
        }
        private void Update()
        {
            if (isMoving) return;
            if (gameParam.playerTurn != true)
            {
                TurnCheck();
                return;
            }

            charaController.PlayerMove();
            gameParam.playerTurn = false;

        }
        private void TurnCheck()
        {
            gameParam.playerTurn = true;
        }
    }
}