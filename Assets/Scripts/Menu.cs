using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text startGameText;
    [SerializeField] private TMP_Text intstructionsText;

    private static string startGameString = "Squeeze Both Triggers to Begin!"+ Environment.NewLine + Environment.NewLine+"Hit ESC to Quit";
    private static string instructionsString = "Destroy the asteroids before they hit you!";
    private static string gameOverString = "Game Over!";

    private static string scoreString = "Score: ";
    private static string livesString = "Lives: ";


    private GameManager gameManager;

    public void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found");
        }

    }
    public void SetScore(int score)
    {       
        if (scoreText != null)
        {
            scoreText.text = scoreString + score;
        }
    }

    public void SetLives(int lives)
    { 
        if (livesText != null)
        {
            livesText.text = livesString + lives;
        }
    }

    public void EndGame()
    {
        StartCoroutine(EndGameSequence());
    }

    public void StartGame()
    {
        startGameText.gameObject.SetActive(false);
        intstructionsText.gameObject.SetActive(false);
    }

    private IEnumerator EndGameSequence()
    {
        gameManager.acceptInput = false;
        startGameText.text = gameOverString;
        startGameText.color = Color.red;
        startGameText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(5);
        startGameText.text = startGameString;
        startGameText.color = Color.white;
        gameManager.acceptInput = true;
    }
}
