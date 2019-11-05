//************************************************
// UIController_Overlay.cs
// targetTfmに入れたキャラを追従するUIプログラム
//************************************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController_Overlay : MonoBehaviour
{

    [SerializeField]
    private Transform targetTfm;                            // 追従するキャラ

    private RectTransform myRectTfm;                        // 追従するため用
    private Vector3 offset = new Vector3(0, 1.5f, 0);       // 追従するキャラとの距離

    void Start()
    {
        // Componentを取得
        myRectTfm = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 pos;

        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);

        // 常についてくる
        RectTransformUtility.ScreenPointToLocalPointInRectangle(myRectTfm, screenPos, Camera.main, out pos);

        myRectTfm.position = pos;
    }
}
