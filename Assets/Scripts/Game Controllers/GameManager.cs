using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameStartedAferPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void Awake()
    {
        CreateSingleton();
    }

    void Start()
    {
        InitializeDifficulty();
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            CheckHighScore(score, coinScore);

            gameStartedFromMainMenu = false;
            gameStartedAferPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);
        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            gameStartedFromMainMenu = false;
            gameStartedAferPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartGame();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    private void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            if (gameStartedAferPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinScore = coinScore;
                PlayerScore.lifeScore = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinScore = 0;
                PlayerScore.lifeScore = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);
            }
        }
    }

    private void CreateSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void InitializeDifficulty()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficulty(0);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);

            GamePreferences.SetMediumDifficulty(1);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficulty(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetIsMusicOn(0);

            PlayerPrefs.SetInt("Game Initialized", 1);
        }
    }

    void CheckHighScore(int score, int coinScore)
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            int currentHighScore = GamePreferences.GetEasyDifficultyHighScore();
            int currentHighestCoins = GamePreferences.GetEasyDifficultyCoinScore();

            if (currentHighScore < score)
            {
                GamePreferences.SetEasyDifficultyHighScore(score);
            }

            if (currentHighestCoins < coinScore)
            {
                GamePreferences.SetEasyDifficultyCoinScore(coinScore);
            }
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            int currentHighScore = GamePreferences.GetMediumDifficultyHighScore();
            int currentHighestCoins = GamePreferences.GetMediumDifficultyCoinScore();

            if (currentHighScore < score)
            {
                GamePreferences.SetMediumDifficultyHighScore(score);
            }

            if (currentHighestCoins < coinScore)
            {
                GamePreferences.SetMediumDifficultyCoinScore(coinScore);
            }
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            int currentHighScore = GamePreferences.GetHardDifficultyHighScore();
            int currentHighestCoins = GamePreferences.GetHardDifficultyCoinScore();

            if (currentHighScore < score)
            {
                GamePreferences.SetHardDifficultyHighScore(score);
            }

            if (currentHighestCoins < coinScore)
            {
                GamePreferences.SetHardDifficultyCoinScore(coinScore);
            }
        }
    }
}
