using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameButtonAnimation : MonoBehaviour
{

    // Animator
    private Animator mAnim;

    public float triggerVal;

    // Start is called before the first frame update
    void Start()
    {
        mAnim = GetComponent<Animator>();

        triggerVal = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        triggerVal = Input.GetAxis("L_R_Trigger");



        if(triggerVal > 0.0f)
        {
            mAnim.SetBool("LT", false);
            mAnim.SetBool("RT", true);
        }

        else if(triggerVal < 0.0f)
        {
            mAnim.SetBool("RT", false);
            mAnim.SetBool("LT", true);
        }

        else if(triggerVal == 0.0f)
        {
            mAnim.SetBool("LT", false);

            mAnim.SetBool("RT", false);

        }
    }
}
