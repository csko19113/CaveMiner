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
                Debug.Log("EntetPlayer");
                await UniTask.Delay(300);
                base.SceneChange(base.scenename.ToString());
                GameManager.instance.goalCallback.Invoke();
            }
        }
    }
}