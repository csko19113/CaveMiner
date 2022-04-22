using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Cave.Main.Shared
{
    public class GoalManager : SceneController
    {
        private async void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                await UniTask.Delay(500);
                base.SceneChange();
                GameManager.instance.goalCallback.Invoke();
            }
        }
    }
}