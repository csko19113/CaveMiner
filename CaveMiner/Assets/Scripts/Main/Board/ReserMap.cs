using UnityEngine;
//Mapのリセットクラス
public class ReserMap : MonoBehaviour
{
    [SerializeField] private BoardData boardData;
    public void ResetMap()
    {
        boardData.Board = new int[boardData.BoardWidth, boardData.BoardHeight];
        for (int i = 0; i < boardData.BoardWidth; i++)
        {
            for (int j = 0; j < boardData.BoardHeight; j++)
            {
                boardData.Board[i, j] = 0;
            }
        }
    }
}
