using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Board;

namespace Cave.Main.Shared
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
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

            boardManager.Create();
        }
        private void Update()
        {
            if (gameParam.playerTurn == false) gameParam.playerTurn = true;
        }
    }
}