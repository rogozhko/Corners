using UnityEngine;


public class GameStatePlayerTwoMove : IGameState
{
    Manager manager = Manager.Instance;
    
    public void Enter()
    {
        Debug.Log("Enter Player Two Move State");
        manager.CurrentPlayer = Player.Two;
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }
}