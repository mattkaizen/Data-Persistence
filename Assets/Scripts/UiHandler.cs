using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class UiHandler : MonoBehaviour
{

    [SerializeField] Text bestScoreText;

    private void Awake()
    {
        //bestScoreText.text = "Best Score: 0";
        //GameManager.Instance.LoadPlayerName();
        GameManager.Instance.LoadPlayerNameJighScore(); 
        //GameManager.Instance.LoadPlayerScore();
        SetStringBestScore();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("main");
    }
    public void LoadMainMenu()
    {
        GameManager.Instance.SavePlayerName();
        GameManager.Instance.SavePlayerScoreNameAndHighScoreName();
        SceneManager.LoadScene("mainMenu");
    }

    public void Exit()
    {

#if UNITY_EDITOR
        GameManager.Instance.SavePlayerName();
        GameManager.Instance.SavePlayerScoreNameAndHighScoreName();
        EditorApplication.ExitPlaymode();

#else
        GameManager.Instance.SavePlayerName();
        GameManager.Instance.SavePlayerScore();
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void SetStringBestScore()
    {
        //if (GameManager.Instance.playerScore == 0)
        bestScoreText.text = "Best Score: " + GameManager.Instance.playerHighScoreName + " " + GameManager.Instance.playerScore;
        //else
        //    bestScoreText.text = "Best Score: 0 ";aa
    }

    public void SetStringBestScore(int i)
    {
        //if (GameManager.Instance.playerName != null /* && GameManager.Instance.playerScore != 0*/)
        Debug.Log("Nuevo nombre  " + GameManager.Instance.playerName);
        bestScoreText.text = "Best Score: " + GameManager.Instance.playerName + " " + i;
        //else
        //    bestScoreText.text = "Best Score: 0 ";aa
    }

    public void ReadStringInput(string a)
    {
        GameManager.Instance.playerName = a;
    }


}