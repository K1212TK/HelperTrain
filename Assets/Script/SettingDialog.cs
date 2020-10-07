using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDialog : MonoBehaviour
{

    public Canvas canvasDiaLog = null;


    // Start is called before the first frame update
    void Start()
    {
        if (canvasDiaLog != null)
        {
            canvasDiaLog.enabled = false;
        }
    }

    //ダイアログを開く
    public void OpenDiaLog()
    {
        //ダイアログを表示する
        canvasDiaLog.enabled = true;

    }

    //OKが押された後の処理
    public void OnclickOkButton()
    {
        //ダイアログキャンバスを非表示に
        canvasDiaLog.enabled = false;
        //メイン画面へシーン遷移
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
