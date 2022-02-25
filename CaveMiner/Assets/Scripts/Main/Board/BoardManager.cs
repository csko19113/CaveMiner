using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cave.Main
{
    public class BoardManager : MonoBehaviour
    {
        private SetBoard setBoard;
        private ReserMap reserMap;
        private CreateDangeon createDangeon;
        void Awake()
        {
            setBoard = gameObject.GetComponent<SetBoard>();
            reserMap = gameObject.GetComponent<ReserMap>();
            createDangeon = gameObject.GetComponent<CreateDangeon>();
        }
        void Start()
        {
            Create();
        }
        private void Create()
        {
            reserMap.ResetMap();
            createDangeon.CreateRoom();
            setBoard.SetBoardObject();
        }
    }
}