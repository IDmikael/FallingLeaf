using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public int sceneID = 1; //next scene

    public Image image;
    public Text title;

    private string loadStr = "";
    private int dotCount = 1; //for loading string

    private bool loadCompleted = false;

    void Start()
    {
        loadStr = "LOADING";

        title.text = loadStr + ".";

        StartCoroutine(LoadingText());
        StartCoroutine(AsyncLoad());
    }

    private IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            image.fillAmount = progress;

            yield return null;
        }

        loadCompleted = true;
    }

    private IEnumerator LoadingText()
    {
        while (!loadCompleted)
        {
            string loadingStr = loadStr;

            if (dotCount < 4)
            {
                title.text += ".";
                dotCount++;
            }               
            else
            {
                title.text = loadStr + ".";
                dotCount = 1;
            }               

            yield return null;
        }
    }
}
