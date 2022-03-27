using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Board;

namespace Cave.Main.Shared
{
    public class GameManager : MonoBehaviour
    {
        public GameManager instance;
        public bool PlayerTurn => playerTurn;
        public int Second => second;
        [SerializeField] private bool playerTurn;//scriptable
        [SerializeField] private BoardManager boardManager;
        [SerializeField] private int second;//scriptable
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
            boardManager.Create();
        }
    }
}