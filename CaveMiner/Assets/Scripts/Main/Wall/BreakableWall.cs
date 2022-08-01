using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Scriptableobject;
using Cave.Main.Shared;

namespace Cave.Main.Wall
{
    public class BreakableWall : MonoBehaviour
    {
        [SerializeField] private int hp;
        [SerializeField] private BoardData boardData;
        [SerializeField] private WallType wallType;
        private ScoreManager scoreManager;

        private void Awake()
        {
            hp = wallType.WallHp;
            scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }


        public void AttackWall(int dmg)
        {
            this.hp -= dmg;
            if (this.hp <= 0)
            {
                this.gameObject.SetActive(false);
                boardData.UpdateObjPos(gameObject.transform);
                scoreManager.wallBreakedCallback.Invoke(wallType.WallPoint);
            }
        }
    }
}