//************************************************
// UIController_Overlay.cs
// targetTfmに入れたキャラを追従するUIプログラム
//************************************************
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField]
    private Canvas canvas;                                      // キャラに追従させるキャンバス
    [SerializeField]
    private Transform targetTfm;                                // 追従するキャラ

    private RectTransform canvasRectTfm;                        
    private RectTransform myRectTfm;                            // 追従するため用
    private Vector3 offset = new Vector3(0, 3.5f, 0);           // 追従するキャラとの距離

    void Start()
    {
        // Componentを取得
        canvasRectTfm = canvas.GetComponent<RectTransform>();
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        // UIの座標
        Vector2 pos;

        // キャンパスのモードによって切り替える
        switch (canvas.renderMode)
        {

            case RenderMode.ScreenSpaceOverlay:
                // キャラクターのワールド座標をスクリーン座標に変換
                myRectTfm.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);

                break;

            case RenderMode.ScreenSpaceCamera:
                // キャラクターのワールド座標をスクリーン座標に変換
                Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
                // UIとキャラのスクリーン座標を照らし合わせる
                RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTfm, screenPos, Camera.main, out pos);
                // 常についてくる
                myRectTfm.localPosition = pos;
                break;

            case RenderMode.WorldSpace:
                myRectTfm.LookAt(Camera.main.transform);

                break;
        }
    }
}
