using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMng : MonoBehaviour
{
    private bool mPausedFlag = false;
    [SerializeField]
    private GameObject mPauseMenuUI = null;
    [SerializeField]
    private GameObject mGameUI = null;
    [SerializeField]
    private Image mfadeImage = null;
    private float mTimeDelay = 1.5f;

    [HideInInspector]
    public static SceneMng mInstance = null;
    public static SceneMng Instance
    {
        get
        {
            if (mInstance == null)
            {
                GameObject obj = new GameObject();
                obj.name = nameof(SceneMng);
                mInstance = obj.AddComponent<SceneMng>();
                DontDestroyOnLoad(obj);

            }
            return mInstance;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mPauseMenuUI != null)
        {
            mPauseMenuUI.SetActive(false);
        }
    }

    void Awake()
    {
        if (mInstance != null && mInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            mInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if (Input.GetKeyDown("escape") && !mPausedFlag)
            {
                Pause();
            }
        }
    }

    public void MoveScene()
    {
        Debug.Log("シーン遷移");
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int maxSceneNum = SceneManager.sceneCountInBuildSettings;
        StartCoroutine(FadeOut());
        SceneManager.LoadScene((activeSceneIndex + 1) % maxSceneNum);
    }

    public void Pause()
    {
        Debug.Log("Pause");
        mGameUI.SetActive(false);
        mPauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        mPausedFlag = true;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        mGameUI.SetActive(true);
        mPauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        mPausedFlag = false;
    }

    private IEnumerator FadeOut()
    {
        Debug.Log("フェードアウト");
        mfadeImage.color = new Color(mfadeImage.color.r, mfadeImage.color.g, mfadeImage.color.b, 0);

        while (mfadeImage.color.a < 1)
        {
            Color plusAlpha = new Color(mfadeImage.color.r, mfadeImage.color.g, mfadeImage.color.b, 1);
            mfadeImage.color = Color.Lerp(mfadeImage.color,plusAlpha, mTimeDelay * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(mTimeDelay);

    }

    private IEnumerator FadeIn()
    {
        Debug.Log("フェードイン");
        mfadeImage.color = new Color(mfadeImage.color.r, mfadeImage.color.g, mfadeImage.color.b, 1);
        while (mfadeImage.color.a > 0 )
        {
            Color minusAlpha = new Color(mfadeImage.color.r, mfadeImage.color.g, mfadeImage.color.b, 0);
            mfadeImage.color = Color.Lerp(mfadeImage.color, minusAlpha, mTimeDelay * Time.deltaTime);
            yield return null;
        }
    }
}
