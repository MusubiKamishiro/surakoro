using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{

    private int[] cameraZoomOutNum = new int[4];
    private Camera camera;

    private float cameraZoomOutSpeed = 0.03f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        cameraZoomOutNum[0] = 79;
        cameraZoomOutNum[1] = 170;
        cameraZoomOutNum[2] = 300;
        cameraZoomOutNum[3] = 350;
    }

    // Update is called once per frame
    void Update()
    {
        Player mPlyaer = Player.FindObjectOfType<Player>();
        if (!mPlyaer.GetGiantFlag(3) && (camera.orthographicSize - cameraZoomOutNum[3]) <= 0)
        {
            camera.orthographicSize = camera.orthographicSize - ((camera.orthographicSize - cameraZoomOutNum[3]) * cameraZoomOutSpeed);
        }
        else if (!mPlyaer.GetGiantFlag(2) && (camera.orthographicSize - cameraZoomOutNum[2]) <= 0)
        {
            camera.orthographicSize = camera.orthographicSize - ((camera.orthographicSize - cameraZoomOutNum[2]) * cameraZoomOutSpeed);
        }
        else if (!mPlyaer.GetGiantFlag(1) && (camera.orthographicSize - cameraZoomOutNum[1]) <= 0)
        {
            camera.orthographicSize = camera.orthographicSize - ((camera.orthographicSize - cameraZoomOutNum[1]) * cameraZoomOutSpeed);
        }
        else if (!mPlyaer.GetGiantFlag(0) && (camera.orthographicSize - cameraZoomOutNum[0]) <= 0)
        {
            camera.orthographicSize = camera.orthographicSize - ((camera.orthographicSize - cameraZoomOutNum[0]) * cameraZoomOutSpeed);
        }
        //for (int i = 0; i < mPlyaerCollider.GetWallNum(); i++)
        //{
        //    if(mPlyaer.GetGiantFlag(i))
        //    {

        //    }
        //}
    }
}
