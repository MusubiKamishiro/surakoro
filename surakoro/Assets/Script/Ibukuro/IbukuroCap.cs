using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IbukuroCap : MonoBehaviour
{
    bool openFlag;
    string enemyTag;
    int enemyTagNum;
    // Start is called before the first frame update
    void Start()
    {
        openFlag = false;
        enemyTag = "";
    }

    void OnCollisionEnter(Collision collision)
    {
        if(enemyTagNum == 1)
        {
            if (collision.gameObject.tag == enemyTag)
            {
                enemyTagNum++;
            }
            else
            {
                openFlag = true;
                enemyTagNum = 0;
            }
        }
        else
        {
            enemyTagNum++;
            enemyTag = collision.gameObject.tag;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
