using UnityEngine;

namespace Cave.Scriptableobject
{
    [CreateAssetMenu(fileName = "WallType", menuName = "ScriptableObjects/WallParam")]
    public class WallType : ScriptableObject
    {
        [SerializeField] private string wallName;
        [SerializeField] private int wallPoint;
        [SerializeField] private int wallHp;
        public string WallName => wallName;
        public int WallPoint => wallPoint;
        public int WallHp => wallHp;
    }
}