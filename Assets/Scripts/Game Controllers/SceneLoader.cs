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
            if (musicBtn.image.sprite != null)
            {
                musicBtn.image.sprite = musicIcons[1];
            }
        }
        else if(GamePreferences.GetIsMusicOn() == 1)
        {
            GamePreferences.SetIsMusicOn(0);
            MusicController.Instance.PlayMusic(false);
            if (musicBtn.image.sprite != null )
            {
                musicBtn.image.sprite = musicIcons[0];
            }
        }
    }

    void PlayMusicCheck()
    {
        if (GamePreferences.GetIsMusicOn() == 1)
        {
            MusicController.Instance.PlayMusic(true);
            if (musicBtn.image.sprite != null)
            {
                musicBtn.image.sprite = musicIcons[1];
            }
        }
        else
        {
            MusicController.Instance.PlayMusic(false);
            if (musicBtn.image.sprite != null)
            {
                musicBtn.image.sprite = musicIcons[0];
            }
        }
    }
}
