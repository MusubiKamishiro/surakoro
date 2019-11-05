using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMng : MonoBehaviour
{
    // Start is called before the first frame update
    private float mDelay = 1f;
    public Button[] mButton;
    private bool mMovingFlag;
    [SerializeField]
    private float mTransSpeed =2f;
    private float[] mDist;
    void Start()
    {
        mDist = new float[mButton.Length];
       // mMovingFlag = new bool[mButton.Length];
        for (int i = 0; i < mButton.Length; i++)
        {
           // mMovingFlag[i] = false;
            mDist[i] = Vector3.Distance(mButton[(i + 1) % mButton.Length].transform.position , mButton[i].transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            MoveButtonToRight();

        }
        //mButton[0].transform.position = Vector3.Slerp(mButton[0].transform.position, mButton[1].transform.position, 2.0f * Time.deltaTime);


    }
    
    void MoveButtonToRight()
    {
        //mMovingFlag = true;
        for (int i = 0; i < mButton.Length;i++)
        {
          
                mButton[i].transform.position = Vector3.Slerp(mButton[i].transform.position, mButton[(i + 1) % mButton.Length].transform.position, mTransSpeed * Time.deltaTime);
        }
        mMovingFlag = false;
    }

    void MoveButtonToLeft()
    {
        mMovingFlag = true;
        for (int i = 0; i < mButton.Length; i++)
        {
            mButton[i].transform.position = Vector3.Slerp(mButton[(i + 1) % mButton.Length].transform.position, mButton[i].transform.position,  mTransSpeed * Time.deltaTime);
        }
        mMovingFlag = false;
    }
}
