using UnityEngine;
///Boardにオブジェクトのオブジェクト位置を記録
public class CreateDangeon : MonoBehaviour
{
    private BoardData boardData;
    public void CreateRoom()
    {
        int roomCount = Random.Range(boardData.RoomCountMin, boardData.RoomCountMin);

        int GrobalRoadPointX = Random.Range(boardData.BoardWidth / 4, boardData.BoardHeight * 3 / 4);
        int GrobalRoadPointY = Random.Range(boardData.BoardWidth / 4, boardData.BoardHeight * 3 / 4);

        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = Random.Range(boardData.RoomLengthMin, boardData.RoomLengthMax);
            int roomHeight = Random.Range(boardData.RoomLengthMin, boardData.RoomLengthMax);

            int roomStartX = Random.Range(boardData.RoomPadding, boardData.BoardWidth - roomWidth - boardData.RoomPadding);
            int roomStartY = Random.Range(boardData.RoomPadding, boardData.BoardHeight - roomHeight - boardData.RoomPadding);

            int itemCount = Random.Range(boardData.ItemCountMin, boardData.ItemCountMax);

            for (int x = 0; x < roomWidth; x++)
            {
                for (int y = 0; y < roomHeight; y++)
                {
                    boardData.Board[roomStartX + x, roomStartY + y] = 1;
                }
            }
        }
    }

    private void CreateRoad(int roomStartX, int roomStartY, int GrobalRoadPointX, int GrobalRoadPointY)
    {

    }
}
