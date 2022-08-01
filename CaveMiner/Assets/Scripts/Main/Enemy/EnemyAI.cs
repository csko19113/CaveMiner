using UnityEngine;
using Cave.Main.Chara;

namespace Cave.Main.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private STATE enemyState;
        private Vector3 target;
        [SerializeField] private EnemyMove enemyMove;
        [SerializeField] private AStar aStar;
        private enum STATE
        {
            idle,
            caution
        }
        public void MoveEnemy(int second)
        {
            enemyState = StateCheck();
            switch (enemyState)
            {
                case STATE.idle:
                    MoveIdleEnemy(second);
                    break;
                case STATE.caution:
                    MoveCautionEnemy();
                    break;
            }
        }

        private void MoveIdleEnemy(int second)
        {
            int xDir = 0;
            int yDir = 0;
            if (second % 4 == 0)
            {
                int judgeNum = Random.Range(0, 2);
                xDir = (judgeNum == 0) ? -1 : 1;
                enemyMove.AttemptMove<CharaController>(xDir, yDir);
                return;
            }
            else if (second % 2 == 0)
            {
                int judgeNum = Random.Range(0, 2);
                yDir = (judgeNum == 0) ? -1 : 1;
                enemyMove.AttemptMove<CharaController>(xDir, yDir);
                return;
            }
        }
        private void MoveCautionEnemy()
        {
            if (transform.position.x != (int)transform.position.x || transform.position.y != (int)transform.position.y)
            {
                return;
            }
            aStar.SearchRoad();
            enemyMove.AttemptMove<CharaController>(aStar.xDir, aStar.yDir);
        }
        private STATE StateCheck()
        {
            target = GameObject.FindWithTag("Player").transform.position;
            float direction = (transform.position - target).sqrMagnitude;

            if (direction <= 9)
            {
                return STATE.caution;
            }
            else
            {
                return STATE.idle;
            }
        }
        public void ReserAttack()
        {
            enemyMove.ReserAttack();
        }
    }
}