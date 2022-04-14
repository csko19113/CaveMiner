using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Main.Shared;
namespace Cave.Main.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private EnemyAI enemyAI;
        [SerializeField] private GameParam gameParam;
        private void Awake()
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            gameManager.enemies.Add(this);
        }
        public void EnemyMove(int second)
        {
            enemyAI.MoveEnemy(second);
        }
    }
}