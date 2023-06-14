using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI score;
    private GameObject scorePanel;
    // Start is called before the first frame update
    void Start()
    {
        scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
        score = scorePanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int actualScore = int.Parse(score.text);
        score.text = AddScore(actualScore).ToString();
    }

    private int AddScore(int actualScore)
    {
        return actualScore += 1;
    }
}
