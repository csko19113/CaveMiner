using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Result
{
    public class RetryController : SceneController
    {
        public void Retry()
        {
            base.SceneChange(base.scenename.ToString());
        }
    }
}