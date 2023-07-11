using System;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField] private int _maxScore;
        [SerializeField] private float _maxObjectSpeedMultiplier;
        [SerializeField] private float _maxSpawnRateMultiplier;
        [SerializeField] private float _spawnRateMultiplier;
        [SerializeField] private float _objectSpeedMultiplier;
        [SerializeField] private GameObject _pipePack;

        private float _actualSpeed;
        private float _actualSpawn;
        private int _lastScore = 0;
        private GameObject _scorePanel;
        private void Start()
        {
            _scorePanel = FindGameObjectByName("ScorePanel");
            _actualSpawn = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<SpawnPipes>().SpawnRatio;
        }

        private void Update()
        {
            CheckPlayerScore();

        }
        private void CheckPlayerScore()
        {
            if (CheckEndGame())
            {
                EndGame();
            }
            if (CheckScore())
            {
                UpdateDifficulty();
                _lastScore = GetScore(_scorePanel);
            }

        }
        private void UpdateDifficulty()
        {
            if (_actualSpawn > _maxSpawnRateMultiplier)
            {
                ReduceSpawnRate();
            }
            //if (_actualSpeed < _maxObjectSpeedMultiplier)
            //{
            //    IncreaseObjectSpeed();
            //}
        }
        private void IncreaseObjectSpeed()
        {
            if (_pipePack.TryGetComponent<PipeController>(out var pipeController))
            {
                pipeController.UpSpeed(_objectSpeedMultiplier);
                _actualSpeed = pipeController.Speed;
            }
            else
            {
                throw new NullReferenceException("pipeCOntroller is null!");
            }
        }
        private void ReduceSpawnRate()
        {
            if (GameObject.FindGameObjectWithTag("SpawnPoint").TryGetComponent<SpawnPipes>(out var spawnPipes))
            {
                spawnPipes.ReduceSpawnRatio(_spawnRateMultiplier);
                _actualSpawn = spawnPipes.SpawnRatio;
            }
            else
            {
                throw new NullReferenceException("SpawnPipes is null!");
            }
        }
        private void EndGame()
        {
            var managerObject = this.transform.parent.gameObject;
            // Call game over controller
        }
        /// <summary>
        /// Check if score is 999 or more
        /// </summary>
        /// <returns></returns>
        private bool CheckEndGame()
        {
            GameObject scorePanel = FindGameObjectByName("ScorePanel");
            return scorePanel != null && GetScore(scorePanel) >= _maxScore;
        }
        private bool CheckScore()
        {
            int score = GetScore(_scorePanel);
            return _scorePanel != null && _lastScore != score && IsScoreDivisibleByTen(score);
        }
        /// <summary>
        /// Find a game object by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private GameObject FindGameObjectByName(string name)
        {
            return GameObject.Find(name);
        }
        /// <summary>
        /// Check if score is divisible by ten
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private bool IsScoreDivisibleByTen(int score)
        {
            return score % 10 == 0 && score != 0;
        }
        /// <summary>
        /// Find and return int score
        /// </summary>
        /// <param name="scorePanel"></param>
        /// <returns>int</returns>
        private int GetScore(GameObject scorePanel)
        {
            TextMeshProUGUI scoreText = scorePanel.GetComponentInChildren<TextMeshProUGUI>();
            int.TryParse(scoreText.text, out int score);
            return score;
        }
    }
}
