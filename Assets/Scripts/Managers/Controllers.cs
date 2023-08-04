using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class Controllers : MonoBehaviour
    {
        private bool _gameStarted = false;
        private bool _paused = false;
        private SpawnGeneralItems _spawnGeneralItems;

        void Start()
        {
            _spawnGeneralItems = FindObjectOfType<SpawnGeneralItems>();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_gameStarted)
                {
                    Invoke(nameof(StartGame), 0.5f);
                    _gameStarted = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_paused)
                {
                    Time.timeScale = 1;
                    _paused = false;
                }
                else
                {
                    Time.timeScale = 0;
                    _paused = true;
                }

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }
        private void StartGame()
        {
            _spawnGeneralItems.StartGame();
        }

    }
}