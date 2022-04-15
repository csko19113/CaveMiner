using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Scriptableobject;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private WallType wallType;

    private void Awake()
    {
        hp = wallType.WallHp;
        //spriteRenderer.sprite = wallType.wallSprite;
    }

    private enum WALLTYPE
    {
        Emerald = 500,
        Amethyst = 800,
        Sapphire = 1000
    }

    public void AttackWall(int dmg)
    {
        //       spriteRenderer.sprite = dmgSprite;
        this.hp -= dmg;
        if (this.hp <= 0)
        {
            this.gameObject.SetActive(false);
            //GameManager.scoreList.Add((int)type);
        }
    }
}
