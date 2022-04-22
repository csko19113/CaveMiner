using UnityEngine;
using Cave.Main.Shared;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Chara
{
    public class CharaController : MonoBehaviour
    {
        [SerializeField] private CharaMove charaMove;
        [SerializeField] private CharaInput charaInput;
        [SerializeField] private GameParam gameParam;
        private void Update()
        {
            //GameManagerから移動をここに移動
            if (GameManager.isMoving) return;
            PlayerMove();
        }
        public async void PlayerMove()
        {
            if (!gameParam.playerTurn) return;

            GameManager.isMoving = true;
            charaInput.InputMoveDirection();
            if (charaInput.Vertical != 0 || charaInput.Horizontal != 0)
            {
                charaMove.AttemptMove<BreakableWall>(charaInput.Horizontal, charaInput.Vertical);
                gameParam.playerTurn = false;
            }
            await UniTask.Delay(250);
            GameManager.isMoving = false;
        }
    }
}