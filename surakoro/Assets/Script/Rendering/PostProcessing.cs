using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PostProcessing : MonoBehaviour
{
    [SerializeField]
    private GameObject[] mPostVolume;
    private int profileNow;
    [SerializeField]
    private Light mLight;
    DateTime mTimeOld;

    // Start is called before the first frame update
    void Start()
    {
        int rand = UnityEngine.Random.Range(0, mPostVolume.Length);
        ChangeWeather(rand);
        mTimeOld = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        var timeNow = DateTime.Now;
        if (timeNow - mTimeOld >= TimeSpan.FromSeconds(10))
        {
            mTimeOld = DateTime.Now;
            ChangeWeather((profileNow + 1) % mPostVolume.Length);
        }
    }

    //ポストプロセスのプロファイルを変える
    public void ChangeWeather(int idx)
    {
        for (int i =0; i< (int)mPostVolume.Length;i++)
        {
            mPostVolume[i].SetActive(false);
        }
        mPostVolume[idx].SetActive(true);
        mLight.shadows = mPostVolume[idx].name == "Night" ? LightShadows.None : LightShadows.Soft;
        profileNow = idx;
    }
    
}
