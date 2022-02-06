using System;
using UnityEngine;


public class Logic3 : ILogic
{
    Manager manager = Manager.Instance;


    public void Run()
    {
        // Если ячейка рядом и нет другой фигуры
        if (CheckIsOneStepAround() && !Arrays.CheckIsOtherFigure())
        {
            RemoveFromArray(manager.CurrentFigure);
            SnapFigure(manager.CurrentFigure);
        }
        else
        {
            BackToCurrentPosition(manager.CurrentFigure);
        }
    }

    #region Move

    private void BackToCurrentPosition(Figure figure)
    {
        figure.transform.position = Utils.GetPositionFromCoordinates(figure.Coordinates);
    }

    private void RemoveFromArray(Figure figure)
    {
        Arrays.figures[figure.Coordinates.Item1, figure.Coordinates.Item2] = null;
    }

    private void SnapFigure(Figure figure)
    {
        var mousePosition = Utils.GetRoundMousePosition();
        var position = Utils.GetPositionFromCoordinates(mousePosition);
        figure.transform.position = position;
        figure.Coordinates = mousePosition;
    }

    #endregion

    
    
    // Первая логика, ходит на одну клетку вокруг
    private bool CheckIsOneStepAround()
    {
        var a = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }
}