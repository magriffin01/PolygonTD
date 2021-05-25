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
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SceneToLoad = "Level1";
    public CanvasGroup MainMenuCanvas;
    public CanvasGroup HowToPlayCanvas;
    public GameObject MainMenuBackground;

    private void Start()
    {
        Show(MainMenuCanvas);
        Hide(HowToPlayCanvas);
        MainMenuBackground.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void LoadHowToPlay()
    {
        Hide(MainMenuCanvas);
        Show(HowToPlayCanvas);
        MainMenuBackground.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Exiting");
        Application.Quit();
    }

    public void Back()
    {
        Hide(HowToPlayCanvas);
        Show(MainMenuCanvas);
        MainMenuBackground.SetActive(true);
    }

    private void Show(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    private void Hide(CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
