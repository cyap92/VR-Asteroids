using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Gun LeftGun;
    [SerializeField] Gun RightGun;
    [SerializeField] InputManager inputManager;
    [SerializeField] Menu menu;
    [SerializeField] EnemySpawn enemySpawn;
    //[SerializeField] GameObject damageOverlay;
    [SerializeField] AudioSource damageAudioSource;

    [SerializeField] private int lives = 10;
    private int score;

    [NonSerialized]
    public bool isPlaying = false;
    [NonSerialized]
    public bool acceptInput = true;

    public static GameManager instance;

    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void FireLeftGun()
    {
        if (LeftGun != null)
        {

            LeftGun.Fire();
        }
        else
        {
            Debug.LogError("Left Gun is null");
        }
    }

    private float lastFiredTimeRight = 0;
    public void FireRightGun()
    {
        
        if (RightGun != null)
        {

            RightGun.Fire();

        }
        else
        {
            Debug.LogError("Right Gun is null");
        }
    }

    public void ScorePoints(int points)
    {
        score += points;
        menu.SetScore(score);
    }

    public void LoseLife()
    {
        lives--;
       // StartCoroutine(DamageCoroutine());
        menu.SetLives(lives);
        if (damageAudioSource != null)
        {
            damageAudioSource.PlayOneShot(damageAudioSource.clip);
        }
        if (lives == 0)
        {
            GameOver();
        }
    }
/*
    private IEnumerator DamageCoroutine()
    {
        if (damageOverlay != null)
        {
            damageOverlay.SetActive(true);
            yield return new WaitForSeconds(.2f);
            damageOverlay.SetActive(false);
        }
    }
    */

    public void GameOver()
    {
        //Debug.Log("GameOver");
        isPlaying = false;
        if (enemySpawn != null)
        {
            enemySpawn.DestroyAllEnemies();
        }
        else
        {
            Debug.LogError("EnemySpawn Missing");
        }
        menu.EndGame();
    }

    public void StartGame()
    {
        if(!acceptInput)
        {
            return;
        }
        //Debug.Log("Start Game");
        isPlaying = true;
        score = 0;
        menu.SetLives(lives);
        menu.SetScore(score);
        menu.StartGame();
        if (enemySpawn != null)
        {
            StartCoroutine(enemySpawn.SpawnEnemies(0));
        }
        else
        {
            Debug.Log("EnemySpawn Missing");
        }
        
    }
}
