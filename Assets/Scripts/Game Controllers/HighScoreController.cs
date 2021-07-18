using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour
{
    [SerializeField]
    private Text scoreText, coinText;

    void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(),
                     GamePreferences.GetEasyDifficultyCoinScore());
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(),
                     GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(),
                     GamePreferences.GetHardDifficultyCoinScore());
        }
    }

    void GoBackToMainMenu(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
