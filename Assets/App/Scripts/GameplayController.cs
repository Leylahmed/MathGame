using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private ArrayElement[] questionsAnswers = new ArrayElement[2];

    [SerializeField] private TextMeshProUGUI levelText;

    [SerializeField] private TextMeshProUGUI equationText;

    [SerializeField] private TextMeshProUGUI answerText;

    [SerializeField] private TextMeshProUGUI checkText;

    private bool isClean = false;

    private int _levelIndex;

    private void Start()
    {
        _levelIndex = PlayerPrefs.GetInt("LevelIndex");

        levelText.text = "Level" + (_levelIndex + 1);

        equationText.text = questionsAnswers[_levelIndex].Element[0];
    }

    public void onEnterButtonPressed()
    {
        if (answerText.text == questionsAnswers[_levelIndex].Element[1])
        {
            checkText.text = "TRUE";
        }
        else checkText.text = "False";
    }


    public void onNumberButtonPressed(int number)
    {

        if (!isClean)
        {
            answerText.text = "";
            isClean = true;
        }
        answerText.text += number;
    }

    public void onCleanTextButtonPressed()
    {
        answerText.text = "enter your answer...";
        isClean = false;
    }

    public void onMainMenuButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void onNextLevelButtonPressed()
    {
        if (checkText.text == "TRUE" && _levelIndex < 9)
        {
            PlayerPrefs.SetInt("LevelIndex", _levelIndex + 1);
            SceneManager.LoadScene("GameplayScene");
        }

        else if (_levelIndex == 9)
        {
            SceneManager.LoadScene("End");
        }
        else return;     
    }

}
[System.Serializable]
public class ArrayElement
{
    public string[] Element = new string[2];
}