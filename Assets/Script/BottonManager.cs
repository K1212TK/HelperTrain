using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BottonManager : MonoBehaviour
{

    const string SOUND_PASS = "Sound/";
    const string SOUND_NAME1 = "警告音1";
    const string SOUND_NAME2 = "警告音2";
    const string SOUND_NAME3 = "警告音3";
    const string SOUND_NAME4 = "警告音4";
    const string SOUND_NAME5 = "警告音5";
    const string PREFAB_PASS = "Prefabs/";
    const string BUTTON_NAME = "StartSoundButton1";

    public GameObject canvas;//キャンバス
    private AudioSource sound;
    private GameObject instance;


    // Start is called before the first frame update
    void Start()
    {
        //座標データの取得
        var vectorMap = CreateVectorDictionary();
        // スタートボタンプレハブをGameObject型で取得
        GameObject buttonObj = (GameObject)Resources.Load(PREFAB_PASS+BUTTON_NAME);

        for (int i = 0; i < vectorMap.Count; i++)
        {
            //配置位置の指定
            Vector3 pos = new Vector3(vectorMap[i][0], vectorMap[i][1], vectorMap[i][2]);
            //インスタンス生成
            instance = Instantiate(buttonObj, pos, Quaternion.identity);
            //canvas内にボタンの配置
            instance.transform.SetParent(canvas.transform, false);
            //各ボタンのインスタンスへBGMを設定する
            SoundSetting(i);

        }

    }
   
    //ボタンを表示させる座標を格納する
    Dictionary<int, List<float>> CreateVectorDictionary()
    {
        Dictionary<int, List<float>> vectorMap = new Dictionary<int, List<float>>();

        vectorMap.Add(0, new List<float>() { 16f, 380f, 0f });
        vectorMap.Add(1, new List<float>() { 16f, 280f, 0f });
        vectorMap.Add(2, new List<float>() { 16f, 180f, 0f });
        vectorMap.Add(3, new List<float>() { 16f, 80f, 0f });
        vectorMap.Add(4, new List<float>() { 16f, -20f, 0f });

        return vectorMap;
    }
    
    //各インスタンスに音声を設定する
    void SoundSetting(int value)
    {
        sound = instance.GetComponent<AudioSource>();

        //各ボタンに対応するサウンドの設定
        switch (value)
        {
            case 0:
                sound.clip = (AudioClip)Resources.Load(SOUND_PASS + SOUND_NAME1);
                break;
            case 1:
                sound.clip = (AudioClip)Resources.Load(SOUND_PASS + SOUND_NAME2);
                break;
            case 2:
                sound.clip = (AudioClip)Resources.Load(SOUND_PASS + SOUND_NAME3);
                break;
            case 3:
                sound.clip = (AudioClip)Resources.Load(SOUND_PASS + SOUND_NAME4);
                break;
            case 4:
                sound.clip = (AudioClip)Resources.Load(SOUND_PASS + SOUND_NAME5);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
