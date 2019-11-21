using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject leaf;
    public GameObject stick;
    public GameObject gameOver;
    public Text gameOverBest;

    public GameObject wind;
    public WeatherController weatherController;
    public LeafController leafController;
    public ScoreController scoreController;

    public GameObject[] buttons;

    //Game start algoritm: press StartBtn -> StartPreGame anim -> StartGame -> Play LeafSwing anim
    private Animation animLeaf;
    private Animation animGame;
    private Vector2 stickStartPos;
    private Vector2 leafStartPos;

    //Exit values (Android only)
    private bool exit = false;
    private int exitCounter = 0;
    private float exitTime = 30.0f;

    void Start()
    {
        stickStartPos = new Vector2(stick.transform.localPosition.x, stick.transform.localPosition.y);
        leafStartPos = new Vector2(leaf.transform.parent.gameObject.transform.localPosition.x, 
            leaf.transform.parent.gameObject.transform.localPosition.y);

        animLeaf = leaf.GetComponent<Animation>();
        animGame = weatherController.gameObject.GetComponent<Animation>();
        animGame.Play("Menu");
    }

    void Update()
    {
        //Exit (Android only)
        if (Application.platform != RuntimePlatform.Android)
            return;

        if (exit)
        {
            exitTime -= Time.deltaTime;
            if (exitTime <= 0.0f)
            {
                exitCounter = 0;
                exit = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && exitCounter == 0)
        {
            GetComponent<ToastMessage>().showToastOnUiThread("Press again to exit");
            exitCounter++;
            exit = true;
            exitTime = 30f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && exitCounter >= 1 && Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer")
                    .GetStatic<AndroidJavaObject>("currentActivity");
            activity.Call("finish");
        }
    }

    public void StartPreGameAnimation()
    {
        SoundHelper.PlayWindSound();
        wind.SetActive(true);
        animGame.Play("StartPreGame");
    }

    public void StartGame()
    {
        leafController.isPlaying = true;
        animLeaf.Play("LeafSwing");
        Debug.Log("anim leaf: " + animLeaf);
        weatherController.StartGame();
        scoreController.GameStart();
    }

    public void showGameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        leaf.SetActive(false);

        float score = PlayerPrefs.GetFloat(PrefsNames.PREF_BEST, 0f);
        gameOverBest.text = Mathf.Round(score * 100f) / 100f + " cm";
    }

    // Buttons Click Sector
    public void onPlay()
    {
        SoundHelper.PlayButtonSound();        

        foreach (GameObject btn in buttons)
        {
            btn.SetActive(false);
        }

        StartPreGameAnimation();
    }

    public void onResume()
    {
        SoundHelper.PlayButtonSound();
        gameOver.SetActive(false);
        Time.timeScale = 1;

        leaf.SetActive(true);
        animGame.Play("Menu");

        stick.transform.localPosition = new Vector3(stickStartPos.x, stickStartPos.y, 35.37f);
        leaf.transform.parent.gameObject.transform.localPosition = new Vector3(leafStartPos.x, leafStartPos.y, 0f);

        foreach (GameObject btn in buttons)
        {
            btn.SetActive(true);
        }
    }

    public void onShop()
    {
        //TODO
        SoundHelper.PlayButtonSound();
        if (Application.platform == RuntimePlatform.Android)
            GetComponent<ToastMessage>().showToastOnUiThread("Not implemented");

    }

    public void onSettings()
    {
        //TODO
        SoundHelper.PlayButtonSound();
        if (Application.platform == RuntimePlatform.Android)
            GetComponent<ToastMessage>().showToastOnUiThread("Not implemented");
    }
}
