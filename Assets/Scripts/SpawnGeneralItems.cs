using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SpawnGeneralItems : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject ScorePanel;
    [SerializeField] private GameObject PipesSpawner;
    [SerializeField] private GameObject UiPanel;
    private TMP_Text score;
    public bool gameStarted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameStarted)
            {
                Invoke(nameof(StartGame), 0.5f);
                gameStarted = true;
            }
        }
    }

    private void StartGame()
    {
        DisableStartUi();
        InstantiateElements();
        ScoreToZero();
    }
    private void InstantiateElements()
    {
        Instantiate(Player);
        Instantiate(ScorePanel);
        Instantiate(PipesSpawner);
    }
    private void ScoreToZero()
    {
        score = GameObject.FindGameObjectWithTag("ScorePanel").GetComponentInChildren<TextMeshProUGUI>();
        score.text = "0";
    }
    private void DisableStartUi()
    {
        var c = UiPanel.GetComponent<UiControlloer>();
        string[] s = { "Get","Ready", "Start" };
        c.ChangeStateItems(s,false);
    }
}
