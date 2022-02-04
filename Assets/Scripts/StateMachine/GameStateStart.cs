using UnityEngine;

public class GameStateStart: IGameState
{
    private Manager manager = Manager.Instance;

    public void Enter()
    {
        manager.GameField.CreateGameField();
        manager.GameField.CreateFigures();

        
        // foreach (var f in Arrays.figures)
        // {
        //     if (f != null)
        //     {
        //         f.ShowDebug();
        //     }
        // }

        Debug.Log(Arrays.CheckIsContain(5, 0));
        
        
        manager.SetGameStatePlayerOneMove();
    }

    public void Exit()
    {
    }

    public void Update()
    {
        
    }
    
    
}