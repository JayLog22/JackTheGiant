using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameoverScoreText, gameoverCoinText;

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject readyButton;

    private float timeToRestartGameAfterLost = 3f;

    void Awake()
    {
        CreateInstance();        
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }

    #region SetScores
    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int score)
    {
        coinText.text = "x" + score;
    }

    public void SetLifeScore(int score)
    {
        lifeText.text = "x" + score;
    }
    #endregion

    #region GameOver
    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameoverScoreText.text = finalScore.ToString();
        gameoverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverGoBackToMainMenu("MainMenu"));
    }

    public void PlayerDiedRestartGame()
    {
        StartCoroutine(PlayerDiedRestart("Gameplay"));
    }

    IEnumerator GameOverGoBackToMainMenu(string mainMenuScene)
    {
        yield return new WaitForSeconds(timeToRestartGameAfterLost);
        SceneManager.LoadScene(mainMenuScene);
    }

    IEnumerator PlayerDiedRestart(string gameplayScene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(gameplayScene);
    }
    #endregion

    #region Pause
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame(string mainMenuScene)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }
    #endregion



}
