using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    //=====Singleton=====
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }
            return _instance;
        }
        private set { _instance = value; }
    }
    #endregion
    public enum GameState { Pause, OnGoing, Gameover}

    public GameState state;

    public GameObject pauseText;
    public GameObject gameoverText;

    public Player playerScript;

    //Score

    public int score;
    public static int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private void Awake()
    {
        PauseGame();
        highScoreText.text = "Highscore: " + highScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            if (state != GameState.Pause)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    private void PauseGame()
    {
        state = GameState.Pause;
        pauseText.SetActive(true);
        gameoverText.SetActive(false);
        playerScript.enabled = false;
        Time.timeScale = 0f;
    }
    private void UnPauseGame()
    {
        state = GameState.OnGoing;
        pauseText.SetActive(false);
        playerScript.enabled = true;
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        state = GameState.Gameover;
        gameoverText.SetActive(true);
        playerScript.enabled = false;
        
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Highscore: " + highScore.ToString();
        }

        Time.timeScale = 0f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Score()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
