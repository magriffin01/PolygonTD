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

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public Wave[] Waves;

    public Transform SpawnPoint;
    public Text WaveCountdownText;
    public float TimeBetweenWaves = 5f;
    private float countdown = 15f;
    private int waveIndex = 0;
    private Game game;

    private void Start()
    {
        game = Game.Instance;
    }

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == Waves.Length)
        {
            game.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = TimeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WaveCountdownText.text = "Wave Timer: " + string.Format("{0:00.00}", countdown);
    }

    // Coroutine that allows enemies to be offset and that 2 don't spawn on top of one another
    private IEnumerator SpawnWave()
    {
        Game.WavesSurvived++;

        Wave wave = Waves[waveIndex];

        EnemiesAlive = wave.EnemyCount;

        for (int enemyNumber = 0; enemyNumber < wave.EnemyCount; enemyNumber++)
        {
            SpawnEnemy(wave.EnemyPrefab);
            yield return new WaitForSeconds(1f / wave.SpawnRate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
    }
}
