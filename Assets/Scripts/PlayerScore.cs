using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    private Text scoreText, gameOverScoreText, bestText;
    public GameObject star1, star2, star3;
    private int score = 0;
    private int highscore;
    float timeLeft = 30.0f;
    
   // PauseMenu pm = new PauseMenu();

    // Use this for initialization
    void Awake () {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        gameOverScoreText = GameObject.Find("score").GetComponent<Text>();
        bestText = GameObject.Find("best").GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "0";
	}
	
	
	void OnTriggerEnter2D (Collider2D target) {
        StartCoroutine(CatchFruits(target));
    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("Highscore", highscore);
                bestText.text = score.ToString();
            }else
            {
                bestText.text = highscore.ToString();
            }
            gameOverScoreText.text = scoreText.text;
            if(score < 10)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }else if(score < 40)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
            }else
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator CatchFruits(Collider2D target)
    {
        if (target.tag == "NotRibenaFruit")
        {
            //transform.position = new Vector2(0, 100);
            //target.gameObject.SetActive(false);
            //StartCoroutine(RestartGame());
            score++;
            scoreText.text = score.ToString();
            yield return new WaitForSecondsRealtime(0.08f);
            target.gameObject.SetActive(false);
            
        }
        if (target.tag == "RibenaFruit")
        {
            score = score + 3;
            scoreText.text = score.ToString();
            yield return new WaitForSecondsRealtime(0.08f);
            target.gameObject.SetActive(false);
            
        }
    }
}
