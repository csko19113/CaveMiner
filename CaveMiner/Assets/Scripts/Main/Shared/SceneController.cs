using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーン遷移用のクラス
public abstract class SceneController : MonoBehaviour
{
    [SerializeField] protected string changeScene;//todo 専用のenumの作成
    protected virtual void SceneChange()
    {
        SceneManager.LoadScene(changeScene);
    }
}
