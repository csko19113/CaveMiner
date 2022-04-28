using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Cave.Main.Shared;
namespace Cave.Main.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public bool IsMoving => isMoving;
        [SerializeField] private EnemyAI enemyAI;
        [SerializeField] private GameParam gameParam;
        [SerializeField] private bool isMoving = false;
        private void Awake()
        {
            GameManager.instance.enemies.Add(this);
            GameManager.instance.goalCallback += () => ResetEnemies();
        }
        public void EnemyMove(int second)
        {
            if (!isMoving)
            {
                isMoving = true;
                enemyAI.MoveEnemy(second);
                isMoving = false;
            }
        }

        private void ResetEnemies()
        {
            GameManager.instance.enemies.Remove(this);
            GameManager.instance.goalCallback -= () => ResetEnemies();
        }
    }
}