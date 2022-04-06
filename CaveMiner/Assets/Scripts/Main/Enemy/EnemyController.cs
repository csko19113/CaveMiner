using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cave.Main.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private EnemyMove enemyMove;
        [SerializeField] private EnemyAI enemyAI;
        [SerializeField] private GameParam gameParam;
    }
}