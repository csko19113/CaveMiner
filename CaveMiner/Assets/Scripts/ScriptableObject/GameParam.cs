using UnityEngine;

[CreateAssetMenu(fileName = "GameParam", menuName = "ScriptableObjects/GameParam")]
public class GameParam : ScriptableObject
{
    public int second = 100;
    public bool playerTurn = true;
}
