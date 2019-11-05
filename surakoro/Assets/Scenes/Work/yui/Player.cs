using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private struct EatStatus
    {
        int time;
        Vector3 size;
    }

    private List<EatStatus> eatStatuses = new List<EatStatus>();

    private float speed = 1.5f;     // デバッグ用のプレイヤー移動速度
    private int eatEnemyNum = 0;    // 敵を食べた数
    private Vector3 growingSize = new Vector3(0, 0, 0);   // 敵を食べて大きくなるサイズ

    private int eatCount = 0;// 食べるのにかかる時間
    private const int eatTime = 60; // 食べてる時間

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // 敵の大きさによってでかくなる(比率変化あり)
            //growingSize = new Vector3(collision.transform.localScale.x / eatCount, collision.transform.localScale.y / eatCount, 0);
            // 敵の大きさによってでかくなる(比率変化なし)
            float mMaxSide = Mathf.Max(collision.transform.localScale.x, collision.transform.localScale.y);
            Vector3 mBigSize = new Vector3(mMaxSide / eatTime, mMaxSide / eatTime, 0);
            growingSize = mBigSize;
            //EatStatus mEstatus = ;
            //eatStatuses.Add(eatTime, growingSize);


            collision.transform.position += new Vector3(0, 0, 5);

            //Destroy(collision.gameObject);
            
            eatCount = eatTime;
            ++eatEnemyNum;  // 当たったということは食べたということ
            Debug.Log("接触");
        }
    }

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

        // 徐々に大きくなる感じ
        if (eatCount > 0)
        {
            transform.localScale += growingSize;
            --eatCount;
        }
    }
}
