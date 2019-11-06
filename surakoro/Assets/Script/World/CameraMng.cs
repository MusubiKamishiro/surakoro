using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMng : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera mCamera;
    private float[] zoomOutSize;
    private int currentZoomSize =0;
    private const int wallBreakNum = 3; //壊れる壁の数
    void Start()
    {
        
        zoomOutSize = new float[wallBreakNum] { 55,155,300 };
        
    }

    // Update is called once per frame
    void Update()
    {
        //ステージ２のカメラサイズ（仮）
        //ZoomOut(25f);
    }
    
    //ステージ変える時ズームアウトする
    public void ZoomOut(int idx)
    {
        if (idx < wallBreakNum && idx >= currentZoomSize)
        {
            var sizeNow = mCamera.orthographicSize;
            mCamera.orthographicSize = Mathf.Lerp(sizeNow, zoomOutSize[idx], 0.5f * Time.deltaTime);
            currentZoomSize = idx;
        }
    }
}
