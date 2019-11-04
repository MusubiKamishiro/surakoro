using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    enum SCENE
    {
        TITLE_SCENE,
        GAME_SCENE,
        RESULT_SCENE
    }
    Button mStartButton;
    SCENE mScene;
    SceneManager mSceneMng;
    // Start is called before the first frame update
    void Start()
    {
        mScene = SCENE.TITLE_SCENE;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeScene()
    {
        // mSceneMng
    }
}
