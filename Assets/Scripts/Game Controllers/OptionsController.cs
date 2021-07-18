using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject easyCheck, mediumCheck, hardCheck;

    void Start()
    {
        GamePreferences.SetIsMusicOn(0);
        SetDifficulty();
    }

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy":
                easyCheck.SetActive(true);
                mediumCheck.SetActive(false);
                hardCheck.SetActive(false);
                break;
            case "Medium":
                easyCheck.SetActive(false);
                mediumCheck.SetActive(true);
                hardCheck.SetActive(false);
                break;
            case "Hard":
                easyCheck.SetActive(false);
                mediumCheck.SetActive(false);
                hardCheck.SetActive(true);
                break;
        }
    }

    void SetDifficulty()
    {
        if (GamePreferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("Easy");
        }

        if (GamePreferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("Medium");
        }

        if (GamePreferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("Hard");
        }
    }

    public void EasyDifficulty()
    {
        GamePreferences.SetEasyDifficulty(1);
        GamePreferences.SetMediumDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easyCheck.SetActive(true);
        mediumCheck.SetActive(false);
        hardCheck.SetActive(false);
    }

    public void MediumDifficulty()
    {
        GamePreferences.SetMediumDifficulty(1);
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetHardDifficulty(0);

        easyCheck.SetActive(false);
        mediumCheck.SetActive(true);
        hardCheck.SetActive(false);
    }

    public void HardDifficulty()
    {
        GamePreferences.SetHardDifficulty(1);
        GamePreferences.SetEasyDifficulty(0);
        GamePreferences.SetMediumDifficulty(0);

        easyCheck.SetActive(false);
        mediumCheck.SetActive(false);
        hardCheck.SetActive(true);
    }

    void GoBackToMainMenu(string mainMenuScene)
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
