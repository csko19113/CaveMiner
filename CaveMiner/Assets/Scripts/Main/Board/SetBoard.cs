using UnityEngine;
///Boardに従いオブジェクトをインスタンス化するクラス
public class SetBoard : MonoBehaviour
{
    [SerializeField] private GameObject wallObject;
    [SerializeField] private GameObject floorObject;
    [SerializeField] private GameObject breakableWall;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject goal;
    [SerializeField] private BoardData boardData;

    public void SetBoardObject()
    {
        SetObject();
        SetPlayer();
        SetGoal();
    }
    private void SetObject()
    {
        for (int x = 0; x < boardData.BoardWidth; x++)
        {
            for (int y = 0; y < boardData.BoardHeight; y++)
            {
                Instantiate(wallObject, new Vector3(x, y, 0), Quaternion.identity);
                if (boardData.Board[x, y] == 1)//floor
                {
                    Instantiate(floorObject, new Vector3(x, y, 0), Quaternion.identity);
                }
                else if (boardData.Board[x, y] == 2)//breakableWall
                {
                    Instantiate(breakableWall, new Vector3(x, y, 0), Quaternion.identity);
                }
                else if (boardData.Board[x, y] == 3)//enemy
                {
                    Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
                }
            }
        }
    }
    private void SetPlayer()
    {
        for (int x = 0; x < boardData.BoardWidth; x++)
        {
            for (int y = 0; y < boardData.BoardHeight; y++)
            {
                //最初に見つけたfloorでプレイヤーを設置
                if (boardData.Board[x, y] == 1)
                {
                    Instantiate(player, new Vector3(x, y, 0), Quaternion.identity);
                    return;
                }

            }
        }
    }
    private void SetGoal()
    {
        for (int x = boardData.BoardWidth - 1; x > 0; x--)
        {
            for (int y = boardData.BoardHeight - 1; y > 0; y--)
            {
                if (boardData.Board[x, y] == 1)
                {
                    Instantiate(goal, new Vector3(x, y, 0), Quaternion.identity);
                    return;
                }

            }
        }
    }
}
