using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Enemy;

namespace Cave.Main.Board
{
    public class BoardManager : MonoBehaviour
    {
        [SerializeField] private SetBoard setBoard;
        [SerializeField] private ReserMap reserMap;
        [SerializeField] private CreateDangeon createDangeon;
        //[SerializeField] private AStarArray aStarArray;
        public void Create()
        {
            Debug.Log("Create");
            reserMap.ResetMap();
            //aStarArray.InputBoard();
            createDangeon.CreateRoom();
            setBoard.SetBoardObject();
        }
    }
}