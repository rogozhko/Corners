using UnityEngine;

public class GameStatePlayerOneMove: IGameState
{
    Manager manager = Manager.Instance;
    
    public void Enter()
    {
        // Debug.Log("First player turn");
        manager.CurrentPlayer = Player.One;
        manager.uiManager.UpdateStateUI();
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
