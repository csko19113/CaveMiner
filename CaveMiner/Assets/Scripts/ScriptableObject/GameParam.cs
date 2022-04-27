using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GameParam", menuName = "ScriptableObjects/GameParam")]
public class GameParam : ScriptableObject
{
    private int defaultSecond = 100;
    public int second = 100;
    public bool playerTurn;
    public UnityAction turnChangeCallBack;
    public void ResetSecond()
    {
        second = defaultSecond;
    }
}
