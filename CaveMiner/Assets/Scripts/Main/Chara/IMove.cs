using System.Collections;
using UnityEngine;

namespace Cave.Main.Chara
{
    public interface IMove
    {
        void AttemptMove<T>(int horizontal, int vertical);
        void MoveCheck(int xDir, int yDir, out RaycastHit2D hit);
        IEnumerator MoveObject(Vector3 startPosition, Vector3 endPosition);
    }
}