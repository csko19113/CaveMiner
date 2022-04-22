using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cave.Main.Board
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private SetBoard setBoard;
        [SerializeField] private ReserMap reserMap;
        [SerializeField] private CreateDangeon createDangeon;
        private BoardManager instance;
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
        }
        public void Create()
        {
            reserMap.ResetMap();
            createDangeon.CreateRoom();
            setBoard.SetBoardObject();
        }
    }
}