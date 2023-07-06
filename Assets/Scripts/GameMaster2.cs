using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//TODO: Corregir la evaluación de la puntuación se hace demasido rapido y no evoluciona correctamente.
public class GameMaster2 : MonoBehaviour
{
    [SerializeField] private int maxSpawnRateMultiplier = 2;
    [SerializeField] private float maxObjectSpeedMultiplier = 5f;
    [SerializeField] private int initialScoreLimit = 100;
    [SerializeField] private int scoreLimit = 999;
    [SerializeField] private GameObject PipePack;

    private SpawnPipes spawnPipes;
    private GameObject scorePanel;
    private TextMeshProUGUI scorePoints;

    private float spawnRateMultiplier;
    private float objectSpeedMultiplier;
    private int score;

    private void Start()
    {
        CheckScorePanel();
    }
    private void Update()
    {
        if (scorePanel != null)
        {
            UpdateScore();
            UpdateDifficulty();
            UpdateScoreLimit();
        }
    }
    private void UpdateDifficulty()
    {
        if (score % 10 == 0 && score != 0)
        {
            if (spawnRateMultiplier > maxSpawnRateMultiplier)
            {
                ReduceSpawnRate();
            }
            if (objectSpeedMultiplier < maxObjectSpeedMultiplier)
            {
                IncreaseObjectSpeed();
            }
        }
    }
    private void UpdateScore()
    {
        int currentScore = int.Parse(scorePoints.text);
        if (currentScore != score)
        {
            score = currentScore;
            if (score >= scoreLimit)
            {
                EndGame();
            }
        }
    }
    private void CheckScorePanel()
    {
        scorePanel = GameObject.Find("ScorePanel");
        if (scorePanel != null)
        {
            InitializeVariables();
        }
    }
    private void InitializeVariables()
    {
        spawnRateMultiplier = 5f;
        objectSpeedMultiplier = 2f;
        scorePoints = scorePanel.GetComponentInChildren<TextMeshProUGUI>();
        score = int.Parse(scorePoints.text);
        spawnPipes = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnPipes>();
        PipeController pipeController = PipePack.GetComponent<PipeController>();
        pipeController.SetSpeed(2f);

    }
    private void UpdateScoreLimit()
    {
        if (score >= initialScoreLimit && score % 10 == 0 && score < scoreLimit)
        {
            int newScoreLimit = initialScoreLimit + (score / 10 * 10);
            if (newScoreLimit <= scoreLimit)
            {
                initialScoreLimit = newScoreLimit;
                Debug.Log("ScoreLimit: " + scoreLimit.ToString());
                Debug.Log("initialScoreLimit: " + initialScoreLimit.ToString());
            }
        }
        //if (score % 100 == 0 && score < scoreLimit)
        //{
        //    scoreLimit += 100;
        //    Debug.Log(scoreLimit.ToString());
        //}
    }
    private void IncreaseObjectSpeed()
    {
        objectSpeedMultiplier += 0.3f;
        PipeController pipeController = PipePack.GetComponent<PipeController>();
        pipeController.SetSpeed(objectSpeedMultiplier);
    }
    private void ReduceSpawnRate()
    {
        spawnRateMultiplier -= 0.3f;
        spawnPipes.SetSpawnPipes(spawnRateMultiplier);
    }
    private void EndGame()
    {
        throw new NotImplementedException();
    }
}
