using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public float score = 0;

    public Text scoreLabel;
    public Text gameOverCurrent;

    private IEnumerator scoreTimer;

    void Start()
    {
        scoreTimer = ScoreTimer(0.1f);
        scoreLabel.text = Mathf.Round(score * 100f) / 100f + " cm";
        scoreLabel.gameObject.SetActive(false);
    }

    public void GameStart()
    {
        scoreLabel.gameObject.SetActive(true);
        StartCoroutine(scoreTimer);
    }

    public void GameOver()
    {
        StopCoroutine(scoreTimer);

        score = Mathf.Round(score * 100f) / 100f;

        //Write best if it's bigger then current best
        float best = PlayerPrefs.GetFloat(PrefsNames.PREF_BEST, 0f);

        if (score > best)
        {
            scoreLabel.text = score + " cm";
            PlayerPrefs.SetFloat(PrefsNames.PREF_BEST, score);
        }
        else
        {
            scoreLabel.text = best + " cm";
        }
        
        gameOverCurrent.text = score + " cm";

        score = 0;
        scoreLabel.gameObject.SetActive(false);
    }

    public IEnumerator ScoreTimer(float interval)
    {

        while (true)
        {
            score += 0.1f;
            scoreLabel.text = Mathf.Round(score * 100f) / 100f + " cm";

            yield return new WaitForSeconds(interval);
        }
    }
}
