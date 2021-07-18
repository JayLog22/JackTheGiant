﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences
{
    public static string EasyDifficulty = "EasyDifficulty";
    public static string MediumDifficulty = "MediumDifficulty";
    public static string HardDifficulty = "HardDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyScore";
    public static string MediumDifficultyHighScore = "MediumDifficultyScore";
    public static string HardDifficultyHighScore = "HardDifficultyScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";
    public static string MediumDifficultyCoinScore = "MediumDifficultyCoinScore";
    public static string HardDifficultyCoinScore = "HardDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";


    // 0 - False       1 - True
    #region Difficulties
    public static void SetEasyDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, difficulty);
    }

    public static int GetEasyDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    public static void SetMediumDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficulty, difficulty);
    }

    public static int GetMediumDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficulty);
    }

    public static void SetHardDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficulty, difficulty);
    }

    public static int GetHardDifficulty()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficulty);
    }
    #endregion

    #region HighScores
    public static void SetEasyDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, score);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    public static void SetMediumDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyHighScore, score);
    }

    public static int GetMediumDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyHighScore);
    }

    public static void SetHardDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyHighScore, score);
    }

    public static int GetHardDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyHighScore);
    }
    #endregion

    #region CoinScores
    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }

    public static void SetMediumDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.MediumDifficultyCoinScore, score);
    }

    public static int GetMediumDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.MediumDifficultyCoinScore);
    }

    public static void SetHardDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.HardDifficultyCoinScore, score);
    }

    public static int GetHardDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.HardDifficultyCoinScore);
    }
    #endregion

    public static void SetIsMusicOn(int value)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, value);
    }

    public static int GetIsMusicOn()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }
}
