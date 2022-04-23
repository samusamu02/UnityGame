using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtlToGameSceneofButtun : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
