using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject _uiPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void GameOver()
    {

    }

    private void DissableItems(bool state)
    {
        var c = _uiPanel.GetComponent<UiController>();
        string[] s = { "Get", "Ready", "Start" };
        c.ChangeStateItems(s, false);
    }
}
