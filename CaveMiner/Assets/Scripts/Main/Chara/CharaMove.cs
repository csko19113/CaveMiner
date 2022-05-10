using UnityEngine;
using Cave.Main.UI;
using Cysharp.Threading.Tasks;
namespace Cave.Main.Chara
{
    public class CharaMove : MonoBehaviour, IMove
    {
        [SerializeField] private bool isMoving;
        [SerializeField] private GameParam gameParam;
        [SerializeField] private BoxCollider2D boxcollider;
        [SerializeField] private LayerMask brockingLayer;
        [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed = 3f;
        [SerializeField] private string paramName;
        public void AttemptMove<T>(int horizontal, int vertical)
        where T : Component
        {
            RaycastHit2D hit;
            if (horizontal != 0)
            {
                animator.SetInteger(paramName, horizontal);
            }
            else if (vertical != 0)
            {
                animator.SetInteger(paramName, vertical * -10);
            }
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
            await UniTask.Delay(150);
            gameParam.playerTurn = false;
            isMoving = false;
            gameParam.second--;
            //gameParam.turnChangeCallBack.Invoke();
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
        public async void OnCantMove<T>(T hitcomponent)
        {
            if (!isMoving)
            {
                PlayerAttack<T>(hitcomponent);
                await UniTask.Delay(150);
                gameParam.second--;
                gameParam.playerTurn = false;
            }
        }

        private async void PlayerAttack<T>(T hitcomponent)
        {
            isMoving = true;
            BreakableWall hit = hitcomponent as BreakableWall;
            hit.AttackWall(1);
            Debug.Log("攻撃");
            await UniTask.Delay(1000);
            isMoving = false;
        }
    }
}