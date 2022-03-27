using UnityEngine;

namespace Cave.Main.Chara
{
    public interface IMove
    {
        void AttemptMove<T>(int horizontal, int vertical) where T : Component;
        void MoveCheck(int xDir, int yDir, out RaycastHit2D hit);
        void MoveObject(Vector3 startPosition, Vector3 endPosition);
    }
}