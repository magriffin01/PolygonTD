/*
# Name: Mark Griffin
# Student ID#: 2340502
# Chapman email: magriffin@chapman.edu
# Course Number and Section: 236-02
# Assignment: Final Project
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public static int Money;
    public static int Health;
    public int StartingMoney = 300;
    public int StartingHealth = 15;
    public static int WavesSurvived;
    public static int EnemiesKilled;

    public static bool IsGameOver = false;

    public Text MoneyText;
    public Text HealthText;
    public GameObject GameOverUI;
    public GameObject LevelCompleteUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one Game in the scene!");
        }

        Instance = this;
    }

    private void Start()
    {
        Money = StartingMoney;
        Health = StartingHealth;
        WavesSurvived = 0;
        EnemiesKilled = 0;
        IsGameOver = false;
    }

    private void Update()
    {
        MoneyText.text = "Money: $" + Money.ToString();
        HealthText.text = "Lives: " + Health.ToString();

        if (IsGameOver)
        {
            return;
        }

        if (!IsPlayerAlive())
        {
            EndGame();
        }
    }

    public void SubtractHealth()
    {
        Health--;
    }

    public void WinLevel()
    {
        IsGameOver = true;
        LevelCompleteUI.SetActive(true);
    }

    private void EndGame()
    {
        IsGameOver = true;
        GameOverUI.SetActive(true);
    }

    private bool IsPlayerAlive()
    {
        if (Health <= 0)
        {
            return false;
        }

        return true;
    }
}
