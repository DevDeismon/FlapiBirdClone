using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private TextMeshProUGUI _score;
    private GameObject _scorePanel;
    void Start()
    {
        _scorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
        _score = _scorePanel.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            int actualScore = int.Parse(_score.text);
            _score.text = AddScore(actualScore).ToString();
        }
    }

    private int AddScore(int actualScore)
    {
        return actualScore += 1;
    }
}
