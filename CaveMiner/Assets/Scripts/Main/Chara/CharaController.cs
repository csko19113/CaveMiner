using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cave.Main.Chara
{
    public class CharaController : MonoBehaviour
    {
        [SerializeField] private CharaMove charaMove;
        [SerializeField] private CharaInput charaInput;
        void Update()
        {
            charaInput.InputMoveDirection();//入力を受け取る
            if (charaInput.Vertical != 0 || charaInput.Horizontal != 0)
            {
                charaMove.AttemptMove<BreakableWall>(charaInput.Horizontal, charaInput.Vertical);
            }
        }
    }
}