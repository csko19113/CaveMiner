using UnityEngine;
///Boardに従いオブジェクトをインスタンス化するクラス
namespace Cave.Main.Board
{
    public class SetBoard : MonoBehaviour
    {
        [SerializeField] private GameObject wallObject;
        [SerializeField] private GameObject[] floorObject;
        [SerializeField] private GameObject[] breakableWalls;
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
                    if (boardData.Board[x, y] == 1)//floor
                    {
                        var f_index = Random.Range(0, floorObject.Length);
                        Instantiate(floorObject[f_index], new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else if (boardData.Board[x, y] == 2)//breakableWall
                    {
                        var f_index = Random.Range(0, floorObject.Length);
                        Instantiate(floorObject[f_index], new Vector3(x, y, 0), Quaternion.identity);
                        var index = Random.Range(0, breakableWalls.Length);
                        Instantiate(breakableWalls[index], new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else if (boardData.Board[x, y] == 3)//enemy
                    {
                        var f_index = Random.Range(0, floorObject.Length);
                        Instantiate(floorObject[f_index], new Vector3(x, y, 0), Quaternion.identity);
                        Instantiate(enemy, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else if (boardData.Board[x, y] == 0)
                    {
                        Instantiate(wallObject, new Vector3(x, y, 0), Quaternion.identity);
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
}