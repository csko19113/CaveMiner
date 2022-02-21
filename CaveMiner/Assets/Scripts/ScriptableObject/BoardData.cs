using UnityEngine;

[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObjects/CreateBoard")]
public class BoardData : ScriptableObject
{
    public int[,] Board;
    [SerializeField] private int boardWidth = 50;
    [SerializeField] private int boardHeight = 50;

    public int BoardWidth => boardWidth;
    public int BoardHeight => boardHeight;
}
