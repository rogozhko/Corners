using UnityEngine;


public class GameStatePlayerTwoMove : IGameState
{
    Manager manager = Manager.Instance;

    public void Enter()
    {
        // Debug.Log("Second player turn");
        manager.CurrentPlayer = Player.Two;
        manager.uiManager.UpdateStateUI();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }

    
}