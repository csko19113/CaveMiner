using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Title
{
    public class StartController : SceneController
    {
        public void StartGame()
        {
            base.SceneChange(base.scenename.ToString());
        }
    }
}