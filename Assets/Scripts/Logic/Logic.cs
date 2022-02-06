using System;
using UnityEngine;

public class Logic
{
    Manager manager = Manager.Instance;

    public virtual void Run()
    {
        // Если ячейка рядом и нет другой фигуры
        if (CheckIsOneStepAround() && !Arrays.CheckIsOtherFigure())
        {
            RemoveFromArray(manager.CurrentFigure);
            MoveFigure(manager.CurrentFigure);
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }
    }

    #region MoveAndSwitchPlayer

    protected void EndMove()
    {
        if (manager.CurrentPlayer == Player.One) manager.FirstPlayerMoves++;
        if (manager.CurrentPlayer == Player.Two) manager.SecondPlayerMoves++;
        
        manager.uiManager.UpdateStateUI();
        
        if (WinLogic.CheckIsWin(manager.CurrentPlayer))
        { 
            manager.SetGameStateResult();
            return;
        }
        
        ChangePlayer();
    }

    

    protected void BackToCurrentPosition(Figure figure)
    {
        figure.transform.position = Utils.GetPositionFromCoordinates(figure.Coordinates);
    }

    protected void RemoveFromArray(Figure figure)
    {
        Arrays.figures[figure.Coordinates.Item1, figure.Coordinates.Item2] = null;
    }

    protected void MoveFigure(Figure figure)
    {
        var mousePosition = Utils.GetRoundMousePosition();
        var position = Utils.GetPositionFromCoordinates(mousePosition);
        figure.transform.position = position;
        figure.Coordinates = mousePosition;

        EndMove();
    }

    private void ChangePlayer()
    {
        if (manager.CurrentPlayer == Player.One)
        {
            manager.SetGameStatePlayerTwoMove();
        }
        else if (manager.CurrentPlayer == Player.Two)
        {
            manager.SetGameStatePlayerOneMove();
        }
    }

    #endregion

    #region For All Logics

    protected bool CheckIsOneStepAround()
    {
        var a = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }

    #endregion
}