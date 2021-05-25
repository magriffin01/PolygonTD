/*
# Name: Mark Griffin
# Student ID#: 2340502
# Chapman email: magriffin@chapman.edu
# Course Number and Section: 236-02
# Assignment: Final Project
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{
    public Text EnemiesKilledText;
    public string MainMenuSceneName = "MainMenu";
    public string NextLevelSceneName;

    private void OnEnable()
    {
        EnemiesKilledText.text = Game.EnemiesKilled.ToString();
    }

    public void Continue()
    {
        SceneManager.LoadScene(NextLevelSceneName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
}
