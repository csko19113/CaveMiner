using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Board;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Shared
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;
        [SerializeField] private bool playerTurn;
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private CameraOffset cameraOffset;
        [SerializeField] private CharacterController characterController;
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
        private async void Update()
        {
            if (gameParam.playerTurn == false)
            {
                await UniTask.Delay(1000);
                gameParam.playerTurn = true;
                return;
            }


        }
    }
}