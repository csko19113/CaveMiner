using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Shared;
namespace Cave.Main.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyAI enemyAI;
        [SerializeField] private GameParam gameParam;
        private void Awake()
        {
            GameManager.instance.enemies.Add(this);
            GameManager.instance.goalCallback += () => ResetEnemies();
        }
        public void EnemyMove(int second)
        {
            enemyAI.MoveEnemy(second);
        }

        private void ResetEnemies()
        {
            GameManager.instance.enemies.Remove(this);
            GameManager.instance.goalCallback -= () => ResetEnemies();
        }
    }
}