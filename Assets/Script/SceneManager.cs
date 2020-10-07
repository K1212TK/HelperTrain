using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public const string MAIN_SCENE_NAME = "MainScene";
    public const string SETTING_SCENE_NAME = "SettingScene";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //設定画面へ遷移
    public void ToSettingScene()
    {
        //script名が同じである為、完全修飾で対応
        UnityEngine.SceneManagement.SceneManager.LoadScene(SETTING_SCENE_NAME);

    }

    public void ToMainScene()
    {
        //script名が同じである為、完全修飾で対応
        UnityEngine.SceneManagement.SceneManager.LoadScene(MAIN_SCENE_NAME);
    }
}
