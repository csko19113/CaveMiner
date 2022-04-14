using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cave.Scriptableobject;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private WallType wallType;

    private enum WALLTYPE
    {
        Emerald = 500,
        Amethyst = 800,
        Sapphire = 1000
    }

    private WALLTYPE type;
    // Start is called before the first frame update
    void Start()
    {
        WallType();
    }

    private void WallType()
    {
        switch (this.gameObject.tag)
        {
            case "Emerald":
                this.hp = 3;
                this.type = WALLTYPE.Emerald;
                break;
            case "Amethyst":
                this.hp = 4;
                this.type = WALLTYPE.Amethyst;
                break;
            case "Sapphire":
                this.hp = 5;
                this.type = WALLTYPE.Sapphire;
                break;
        }
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
