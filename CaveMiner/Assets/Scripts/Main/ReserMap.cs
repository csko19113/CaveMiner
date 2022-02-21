using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Mapのリセットクラス
public class ReserMap : MonoBehaviour
{
    [SerializeField] private BoardData boardData;
    public void ResetMap()
    {
        for (int i = 0; i < boardData.mapWidth; i++)
        {
            for (int j = 0; j < boardData.mapHeight; j++)
            {
                boardData.Board[i, j] = 0;
            }
        }
    }
}
