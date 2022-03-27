using UnityEngine;

namespace Cave.Main.Chara
{
    public class CharaController : MonoBehaviour
    {
        [SerializeField] private CharaMove charaMove;
        [SerializeField] private CharaInput charaInput;
        [SerializeField] private GameParam gameParam;
        void Update()
        {
            if (!gameParam.playerTurn) return;

            charaInput.InputMoveDirection();//入力を受け取る
            if (charaInput.Vertical != 0 || charaInput.Horizontal != 0)
            {
                charaMove.AttemptMove<BreakableWall>(charaInput.Horizontal, charaInput.Vertical);
                gameParam.playerTurn = false;
            }
        }
    }
}