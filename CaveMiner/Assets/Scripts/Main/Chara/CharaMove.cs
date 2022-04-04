using UnityEngine;
using Cysharp.Threading.Tasks;
namespace Cave.Main.Chara
{
    public class CharaMove : MonoBehaviour, IMove
    {
        [SerializeField] private bool isMoving;
        [SerializeField] private BoxCollider2D boxcollider;
        [SerializeField] private LayerMask brockingLayer;
        [SerializeField] private float moveSpeed = 3f;
        public void AttemptMove<T>(int horizontal, int vertical)
        where T : Component
        {
            RaycastHit2D hit;
            MoveCheck(horizontal, vertical, out hit);
            if (hit.transform == null)
            {
                return;
            }

            T hitcomponent = hit.transform.GetComponent<T>();
            //hitcomponentがTの型でないときnullになる。
            if (!isMoving && hitcomponent != null)//動いてないかつ、指定した障害物にあたっている
            {
                OnCantMove(hitcomponent);
            }
        }
        public async void MoveObject(Vector3 startPosition, Vector3 endPosition)
        {
            isMoving = true;
            float direction = (startPosition - endPosition).sqrMagnitude;
            //目的地までの距離がほぼ0になるまで移動
            while (direction > float.Epsilon)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
                direction = (transform.position - endPosition).sqrMagnitude;
                await UniTask.DelayFrame(1);
                //unitaskで1フレーム待つ
            }
            transform.position = endPosition;
            isMoving = false;
        }
        public void MoveCheck(int xDir, int yDir, out RaycastHit2D hit)
        {
            Vector3 StartPosition = transform.position;
            Vector3 EndPosition = StartPosition + new Vector3(xDir, yDir, 0);
            boxcollider.enabled = false;
            hit = Physics2D.Linecast(StartPosition, EndPosition, brockingLayer);
            boxcollider.enabled = true;
            //行先に何もなく、現在動いていない状態
            if (hit.transform == null && !isMoving)
            {
                MoveObject(StartPosition, EndPosition);
                return;
            }
        }
        public void OnCantMove<T>(T hitcomponent)
        {
        }
    }
}