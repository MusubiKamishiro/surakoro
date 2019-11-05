using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMng : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Camera mCamera;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //ステージ２のカメラサイズ（仮）
        //ZoomOut(25f);
    }
    
    public void ZoomOut(float changedSize)
    {
        var sizeNow = mCamera.orthographicSize;
        mCamera.orthographicSize = Mathf.Lerp(sizeNow, changedSize, 0.3f * Time.deltaTime);
    }
}
