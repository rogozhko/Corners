using UnityEngine;

public class GameStateStart: IGameState
{
    private Manager manager = Manager.Instance;

    public void Enter()
    {
        manager.GameField.CreateGameField();
        manager.GameField.CreateFigures();

        
        manager.SetGameStatePlayerOneMove();
    }

    public void Exit()
    {
    }

    public void Update()
    {
        
    }
    
    
}