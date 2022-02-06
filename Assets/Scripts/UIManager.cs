using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public delegate void RestartGame();

public class UIManager : MonoBehaviour
{
    public event RestartGame OnRestartGame;
    
    private Manager manager;
    
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text firstPlayerMoves;
    [SerializeField] private TMP_Text secondPlayerMoves;
    [SerializeField] private GameObject panel;

    private void Start()
    {
        manager = Manager.Instance;
    }
    
    public void UpdateStateUI()
    {
        if (manager.CurrentPlayer == Player.One)
        {
            text.text = "First Player Turn";
        }
        
        if (manager.CurrentPlayer == Player.Two)
        {
            text.text = "Second Player Turn";
        }

        firstPlayerMoves.text = manager.FirstPlayerMoves.ToString();
        secondPlayerMoves.text = manager.SecondPlayerMoves.ToString();
    }
    
    public void UpdateStateUI(string inText)
    {
        text.text = inText;
    }

    public void ShowWinPanel(string text)
    {
        panel.GetComponentInChildren<TMP_Text>().text = text;
        panel.gameObject.SetActive(true);
    }

    public void Restart()
    {
        OnRestartGame?.Invoke();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Lobby");
    }
    
}
