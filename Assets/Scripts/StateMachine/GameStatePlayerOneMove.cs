using UnityEngine;

public class GameStatePlayerOneMove: IGameState
{
    Manager manager = Manager.Instance;
    
    public void Enter()
    {
        Debug.Log("Enter Player One Move State");
        manager.CurrentPlayer = Player.One;
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}
