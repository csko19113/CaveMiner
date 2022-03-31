using UnityEngine;
///Boardにオブジェクトのオブジェクト位置を記録
public class CreateDangeon : MonoBehaviour
{
    [SerializeField] private BoardData boardData;
    public void CreateRoom()
    {
        int enemyCount = 1;//部屋当たりの敵の数
        int roomCount = Random.Range(boardData.RoomCountMin, boardData.RoomCountMin);

        int GrobalRoadPointX = Random.Range(boardData.BoardWidth / 4, boardData.BoardHeight * 3 / 4);
        int GrobalRoadPointY = Random.Range(boardData.BoardWidth / 4, boardData.BoardHeight * 3 / 4);

        for (int i = 0; i < roomCount; i++)
        {
            int roomWidth = Random.Range(boardData.RoomLengthMin, boardData.RoomLengthMax);
            int roomHeight = Random.Range(boardData.RoomLengthMin, boardData.RoomLengthMax);

            int roomStartX = Random.Range(boardData.RoomPadding, boardData.BoardWidth - roomWidth - boardData.RoomPadding);
            int roomStartY = Random.Range(boardData.RoomPadding, boardData.BoardHeight - roomHeight - boardData.RoomPadding);

            //roomの中に道の開始点を作る
            int roadStartPointX = Random.Range(roomStartX, roomStartX + roomWidth);
            int roadStartPointY = Random.Range(roomStartY, roomStartY + roomHeight);

            int itemCount = Random.Range(boardData.ItemCountMin, boardData.ItemCountMax);

            for (int x = 0; x < roomWidth; x++)
            {
                for (int y = 0; y < roomHeight; y++)
                {
                    boardData.Board[roomStartX + x, roomStartY + y] = 1;//floor
                }
            }
            CreateRoad(roadStartPointX, roadStartPointY, GrobalRoadPointX, GrobalRoadPointY);
            LayoutObject(roomStartX, roomStartY, roomWidth, roomHeight, itemCount, 2);//BreakWallを配置
            LayoutObject(roomStartX, roomStartY, roomWidth, roomHeight, enemyCount, 3);
        }
    }
    private void CreateRoad(int roadStartX, int roadStartY, int GrobalRoadPointX, int GrobalRoadPointY)
    {
        int RandomJudge = Random.Range(0, 2);
        if (RandomJudge == 0)
        {
            while (roadStartX != GrobalRoadPointX)
            {
                //xが同じになるまで移動、現在地をfloorにを繰り返す(道にする)
                roadStartX = CompareRoadPoint(roadStartX, GrobalRoadPointX);
                boardData.Board[roadStartX, roadStartY] = 1;
            }

            while (roadStartY != GrobalRoadPointY)
            {
                //yが同じになるまで移動、現在地をfloorにを繰り返す(道にする)
                roadStartY = CompareRoadPoint(roadStartY, GrobalRoadPointY);
                boardData.Board[roadStartX, roadStartY] = 1;
            }
        }
        else//y軸方向から移動する
        {
            while (roadStartY != GrobalRoadPointY)
            {
                roadStartY = CompareRoadPoint(roadStartY, GrobalRoadPointY);
                boardData.Board[roadStartX, roadStartY] = 1;
            }
            while (roadStartX != GrobalRoadPointX)
            {
                roadStartX = CompareRoadPoint(roadStartX, GrobalRoadPointX);
                boardData.Board[roadStartX, roadStartY] = 1;
            }
        }
    }
    private int CompareRoadPoint(int roadStartPoint, int GrobalRoadPoint)
    {
        if (roadStartPoint < GrobalRoadPoint)
        {
            roadStartPoint++;
        }
        else
        {
            roadStartPoint--;
        }
        return roadStartPoint;
    }
    private void LayoutObject(int roomStartX, int roomStartY, int roomWidth, int roomHeight, int itemCount, int objectType)
    {
        int count = 0;
        while (count < itemCount)
        {
            //道を塞がないように1開ける
            int x = Random.Range(roomStartX + 1, roomStartX + roomWidth - 1);
            int y = Random.Range(roomStartY + 1, roomStartY + roomHeight - 1);
            if (boardData.Board[x, y] == 1)
            {
                boardData.Board[x, y] = objectType;
                count++;
            }
        }
    }
}
