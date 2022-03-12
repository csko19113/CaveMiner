using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cave.Main.Chara
{
    public class CharaInput : MonoBehaviour
    {
        [SerializeField] private int horizontal;
        [SerializeField] private int vertical;
        public int Horizontal => horizontal;
        public int Vertical => vertical;
        private void Update()
        {
            horizontal = (int)Input.GetAxisRaw("Horizontal");
            vertical = (int)Input.GetAxisRaw("Vertical");

            if (horizontal != 0 && vertical != 0)//斜め移動の禁止
            {
                horizontal = 0;
                vertical = 0;
            }
        }
    }
}