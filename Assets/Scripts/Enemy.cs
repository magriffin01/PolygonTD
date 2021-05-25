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

public class Enemy : MonoBehaviour
{
    public float StartSpeed = 5;
    public int StartHealth = 100;
    public int DeathReward = 50;
    [HideInInspector]
    public float MovementSpeed;
    private float Health;
    private bool isDead = false;

    private Transform target;
    private int waypointIndex = 0;

    public Image HealthBar;
    private Game game;

    private void Start()
    {
        target = Waypoints.Points[0];
        game = Game.Instance;
        MovementSpeed = StartSpeed;
        Health = StartHealth;
    }

    private void Update()
    {
        Vector2 direction = target.position - transform.position;
        transform.Translate(direction.normalized * MovementSpeed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.01f)
        {
            GetNextWaypoint();
        }
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;

        HealthBar.fillAmount = Health / StartHealth;

        if ((Health <= 0) && (!isDead))
        {
            Die();
        }
    }

    public void Slow(float amount)
    {
        MovementSpeed = StartSpeed * (1f - amount);
        Invoke("ResetMovementSpeed", 2);
    }

    private void ResetMovementSpeed()
    {
        MovementSpeed = StartSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.Points.Length - 1)
        {
            ReachedEnd();
            return;
        }

        waypointIndex++;
        target = Waypoints.Points[waypointIndex];
    }

    private void ReachedEnd()
    {
        game.SubtractHealth();
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void Die()
    {
        isDead = true;
        Game.EnemiesKilled++;
        Game.Money += DeathReward;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
