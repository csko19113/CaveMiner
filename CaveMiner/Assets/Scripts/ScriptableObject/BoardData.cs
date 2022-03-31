using UnityEngine;

[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObjects/CreateBoard")]
public class BoardData : ScriptableObject
{
    public int[,] Board;//0:wall,1:floor,2:breakableWall,3:enemy
    [SerializeField] private int boardWidth = 50;
    [SerializeField] private int boardHeight = 50;
    [SerializeField] private int roomPadding = 5;
    [SerializeField] private int roomCountMin = 5;
    [SerializeField] private int roomCountMax = 10;
    [SerializeField] private int roomLengthMin = 5;
    [SerializeField] private int roomLengthMax = 10;
    [SerializeField] private int itemCountMin = 5;
    [SerializeField] private int itemCountMax = 10;


    public int BoardWidth => boardWidth;
    public int BoardHeight => boardHeight;
    public int RoomPadding => roomPadding;
    public int RoomCountMin => roomCountMin;
    public int RoomCountMax => roomCountMax;
    public int RoomLengthMin => roomLengthMin;
    public int RoomLengthMax => roomLengthMax;
    public int ItemCountMax => itemCountMax;
    public int ItemCountMin => itemCountMin;
}
