using UnityEngine;

[CreateAssetMenu(fileName = "GameParam", menuName = "ScriptableObjects/GameParam")]
public class GameParam : ScriptableObject
{
    [SerializeField] private int second = 100;
    [SerializeField] private bool playerTurn = true;
    public int Second => second;
    public bool PlayerTurn => playerTurn;
}
