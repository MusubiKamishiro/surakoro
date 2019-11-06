using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 1.5f;     // デバッグ用のプレイヤー移動速度
    private Vector3 growingSize = new Vector3(20, 20, 0);	// 敵を食べて大きくなるサイズ
    private bool giantFlag = true;
    private int count = 0;

	public int firstWallBreakCount = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用の移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

		PlayerCollider pc = FindObjectOfType<PlayerCollider>();
		if(pc.GetTotalEatNum() > firstWallBreakCount)
		{
			if (giantFlag)
			{
				Giant();
			}
		}
    }

    void Giant()
    {
        transform.localScale += growingSize / 60;
        if (count > 60)
        {
            giantFlag = false;
            growingSize *= 2;
            count = 0;
			giantFlag = false;
		}
        ++count;
    }
}
