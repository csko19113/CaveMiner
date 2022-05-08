using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cave.Main.Title
{
    public class StartController : SceneController
    {
        public void StartGame()
        {
            base.SceneChange(base.scenename.ToString());
        }
    }

}