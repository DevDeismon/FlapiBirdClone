using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private GameObject _scorePanel;
    private UiController _uiController;
    void Start()
    {
        SetFinalScore();
        DisableScorePanel();
        ActiveFinalPanel();
    }

    private void ActiveFinalPanel()
    {
        _uiController = _uiPanel.GetComponent<UiController>();
        string[] s = { "FinalScore","Game", "Restart", "Over" };
        _uiController.ChangeStateInactiveItems(s);
    }

    private void DisableScorePanel()
    {
        _scorePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void SetFinalScore()
    {
        TextMeshProUGUI score = _scorePanel.GetComponentInChildren<TextMeshProUGUI>();
        GameObject finalScore = _uiPanel.transform.Find("FinalScore").gameObject;
        finalScore.GetComponent<TextMeshProUGUI>().text = score.text;
    }
}
