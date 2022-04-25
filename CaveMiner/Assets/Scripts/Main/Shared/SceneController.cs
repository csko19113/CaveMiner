using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーン遷移用のクラス
public abstract class SceneController : MonoBehaviour
{
    protected enum Scenes
    {
        Title,
        Main,
        Result
    }
    protected virtual void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
