//--------------------------------------------------------------------//
// リザルト時、タイトルに戻るボタンを表示,非表示
//                                             Yutaro Ono.
//-------------------------------------------------------------------//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButtom : MonoBehaviour
{
    // UIのボタン格納
    public GameObject buttomImg;

    // Resultスクリプト格納用
    Result result;


    // InputManagerオブジェクト
    public GameObject inputObj;
    // InputManager
    [SerializeField]
    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        // ボタンイメージの取得
        buttomImg = GameObject.Find("ResultButtomUI");
        buttomImg.SetActive(false);

        // Resultスクリプトが入ったオブジェクトを取得
        GameObject resultHall = GameObject.Find("ResultHall");
        result = resultHall.GetComponent<Result>();

        inputObj = GameObject.Find("InputManager");
        input = inputObj.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {

        // スライムが落ちている状態で非表示
        if(result.flag == true)
        {
            buttomImg.SetActive(false);
        }
        // スライムが落ちきったら表示
        else if(result.flag == false)
        {
            buttomImg.SetActive(true);

        }

        // ボタン押下時処理
        if (input.GetEnter())
        {
            SceneManager.LoadScene("TitleScene 2");
        }

        if (input.GetCancel())
        {
            Application.Quit();
        }

    }
}
