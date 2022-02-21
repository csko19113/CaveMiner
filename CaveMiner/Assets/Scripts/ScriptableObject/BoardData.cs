using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoardData", menuName = "ScriptableObjects/CreateBoard")]
public class BoardData : ScriptableObject
{
    public int[,] Board = new int[50, 50];
    public int mapWidth = 50;
    public int mapHeight = 50;
}
