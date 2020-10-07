using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound01;
    public Text soundText;
    public bool playFlg;


    //Resouseフォルダ内のSoundが格納されているファイルパス
    public const string RESOUSE_SOUND_PASS = "Sound/";
    //デフォルトで設定するSOUND名
    public const string DEFAULT_SOUND_NAME = "警告音1";
    //ユーザーが設定したSOUNDのkey名
    public const string PLAYER_PREFS_SOUND_KEY_NAME = "userSetSound";
    //再生時表示テキスト
    public const string PLAY_SOUND_TEXT = "再生";
    //停止時表示テキスト
    public const string STOP_SOUND_TEXT = "停止";

    void Start()
    {
        sound01 = GetComponent<AudioSource>();
        soundText = GetComponentInChildren<Text>();

    }

    //警告音の再生
    public void OnClick()
    {
        //フラグがfalseかつマネージャーのフラグがfalseの場合は再生
        //else if trueの場合は停止
        if (!playFlg)
        {
            //サウンドの再生
            PlaySound();
        }
        else if(playFlg)
        {
            //サウンドの停止
            StopSound();
        }
    }

    //警告音の視聴
    public void PlaySound()
    {
        sound01.Play();
        soundText.text = STOP_SOUND_TEXT;
        //フラグをtrueに設定する。
        playFlg = true;
        //サウンドが再生されている最中かの判定を行う。再生が終了していた場合StopSoundを呼び出す
        StartCoroutine(Checking(() => {
            StopSound();
        }));
    }

    //警告音の視聴停止
    public void StopSound()
    {
        sound01.Stop();
        soundText.text = PLAY_SOUND_TEXT;
        //フラグをfalseへ戻す
        playFlg = false;
    }

    //PlayerPrefsに設定した音声を再生する。
    public void PlayPlayerPrefsSound()
    {
        //ユーザーが設定したサウンドの取得。ユーザー設定が存在しない場合、デフォルト音声の設定
        string soundName = PlayerPrefs.GetString(PLAYER_PREFS_SOUND_KEY_NAME, DEFAULT_SOUND_NAME);
        //取得したサウンド名をもとにLOAD
        sound01.clip = (AudioClip)Resources.Load(RESOUSE_SOUND_PASS + soundName);
        //再生
        sound01.Play();

        playFlg = true;
    }

    //PlayerPrefsの音声を停止する。
    public void StopPlayerPrefsSound()
    {
        sound01.Stop();

        playFlg = false;
    }

    //警告ボタンが押された際の処理
    public void OnClickDangerSoundBotton()
    {
        //フラグがfalseかつマネージャーのフラグがfalseの場合は再生
        if (!playFlg)
        {
            //サウンドの再生
            PlayPlayerPrefsSound();

        }
        else if (playFlg)
        {
            //サウンドの停止
            StopPlayerPrefsSound();
        }
    }



    public delegate void functionType();
    private IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!sound01.isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
