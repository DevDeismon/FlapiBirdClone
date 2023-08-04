using Assets.Scripts;
using TMPro;
using UnityEngine;

public class SpawnGeneralItems : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _scorePanel;
    [SerializeField] private GameObject _pipesSpawner;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _pipePack;
    
    public void StartGame()
    {
        DisableStartUi();
        EnableScorePanel();
        ResetPipePack();
        InstantiateElements();
        ScoreToZero();
        Invoke(nameof(WakeUpGm), 1f);
    }
    private void ResetPipePack()
    {
        PipeController pipeController = _pipePack.GetComponent<PipeController>();
        pipeController.SetSpeed(2f);
    }
    private void WakeUpGm()
    {
        var gm = this.GetComponent<GameMaster>();
        gm.enabled = true;
    }
    private void EnableScorePanel()
    {
        _scorePanel.SetActive(true);
    }
    private void InstantiateElements()
    {
        Instantiate(_player);
        Instantiate(_pipesSpawner);
    }
    private void ScoreToZero()
    {
        TMP_Text score = _scorePanel.GetComponentInChildren<TextMeshProUGUI>();
        score.text = "0";
    }
    private void DisableStartUi()
    {
        var c = _uiPanel.GetComponent<UiController>();
        string[] s = { "Get", "Ready", "Start" };
        c.ChangeStateActiveItems(s);
    }
}
