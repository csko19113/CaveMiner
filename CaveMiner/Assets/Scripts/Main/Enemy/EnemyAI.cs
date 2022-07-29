using UnityEngine;
using Cave.Main.Chara;

namespace Cave.Main.Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private STATE enemyState;
        private Vector3 target;
        [SerializeField] private EnemyMove enemyMove;
        [SerializeField] private AStarArray aStarArray;
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
        /*
                private void MoveCautionEnemy()
                {
                    int xDir = 0;
                    int yDir = 0;
                    target = GameObject.FindWithTag("Player").transform.position;
                    if (target.x != transform.position.x)
                    {
                        xDir = (target.x > transform.position.x) ? 1 : -1;
                        enemyMove.AttemptMove<CharaController>(xDir, yDir);
                        return;
                    }
                    else if (target.y != transform.position.y)
                    {
                        yDir = (target.y > transform.position.y) ? 1 : -1;
                        enemyMove.AttemptMove<CharaController>(xDir, yDir);
                        return;
                    }

                }
        */
        private void MoveCautionEnemy()
        {
            aStarArray.SearchRoad();
            enemyMove.AttemptMove<CharaController>(aStarArray.xDir, aStarArray.yDir);
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