using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBottonManager : MonoBehaviour
{

    //ユーザー設定情報を保存する際のkey名
    const string PREFS_KEY_NAME = "userSetSound";
    //呼び出すCanvas名
    const string FIND_CANVAS_NAME = "DiaLogCanvas";

    public AudioSource sound;
    //ダイアログのオブジェクト
    GameObject diaLogCanvas;
    SettingDialog settingDialogScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject bottonObj = transform.parent.gameObject;
        sound = bottonObj.GetComponent<AudioSource>();
        diaLogCanvas = GameObject.Find(FIND_CANVAS_NAME);
        //ダイアログのスクリプト取得
        settingDialogScript = diaLogCanvas.GetComponent<SettingDialog>();
    }

    //ユーザーの選択したBGMを設定する
    public void SettingSound()
    {
        //ユーザーが選択したSOUNDの設定
        PlayerPrefs.SetString(PREFS_KEY_NAME, sound.clip.name);
        //設定の保存
        PlayerPrefs.Save();
        //設定完了時のダイアログを表示
        settingDialogScript.OpenDiaLog();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
