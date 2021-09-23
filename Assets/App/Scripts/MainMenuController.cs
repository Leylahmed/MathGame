using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    public void onPlayButtonPressed()
    {
        PlayerPrefs.SetInt("LevelIndex", 0);
        SceneManager.LoadScene("GameplayScene");
    }

    public void onLevelsButtonPressed()
    {
        mainMenuPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    public void onLevelSelectButtonPressed(int levelIndex)
    {
        PlayerPrefs.SetInt("LevelIndex", levelIndex);

        SceneManager.LoadScene("GameplayScene");
    }

    public void onExitButtonPressed()
    {
        Application.Quit();
    }

    public void onLevelsCloseButtonPressed()
    {
        levelsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }


}
