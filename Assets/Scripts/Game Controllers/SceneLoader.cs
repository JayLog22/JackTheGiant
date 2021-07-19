using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    private void Start()
    {
        PlayMusicCheck();
    }

    public void LoadScene(string sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (sceneName == "Gameplay" && currentScene.name == "MainMenu")
        {
            GameManager.instance.gameStartedFromMainMenu = true;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreferences.GetIsMusicOn() == 0)
        {
            GamePreferences.SetIsMusicOn(1);
            MusicController.Instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
        else if(GamePreferences.GetIsMusicOn() == 1)
        {
            GamePreferences.SetIsMusicOn(0);
            MusicController.Instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }

    void PlayMusicCheck()
    {
        int isMusicOn = GamePreferences.GetIsMusicOn();
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (isMusicOn == 1)
            {
                MusicController.Instance.PlayMusic(true);
                musicBtn.image.sprite = musicIcons[1];
            }
            else
            {
                MusicController.Instance.PlayMusic(false);
                musicBtn.image.sprite = musicIcons[0];
            }
        }
    }
}
