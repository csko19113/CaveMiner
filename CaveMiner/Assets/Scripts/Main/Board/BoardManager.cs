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
        public void Create()
        {
            reserMap.ResetMap();
            createDangeon.CreateRoom();
            setBoard.SetBoardObject();
        }
    }
}