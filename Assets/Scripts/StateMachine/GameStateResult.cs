using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStateResult : IGameState
{
    Manager manager = Manager.Instance;
    
    public void Enter()
    {
        Debug.Log("Enter Result State");
        
        manager.uiManager.UpdateStateUI("");
        
        if(manager.CurrentPlayer == Player.One) manager.uiManager.ShowWinPanel("First Player Win!");
        if(manager.CurrentPlayer == Player.Two) manager.uiManager.ShowWinPanel("Second Player Win!");

        manager.uiManager.OnRestartGame += RestartGame;
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
        SceneManager.LoadScene("Lobby");
    }
}