using UnityEngine;
public class GameStateResult : IGameState
{
    public void Enter()
    {
        Debug.Log("Enter Result State");
        
    }

    public void Exit()
    {
    }

    public void Update()
    {
    }

    private void DebugPlayerWin(Player player)
    {
        if(player == Player.One) Debug.Log("First(Blue) Player Won!");
        if(player == Player.Two) Debug.Log("Second(Red) Player Won!");
    }
}