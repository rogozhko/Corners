using System;
using UnityEngine;

public class Logic2 : ILogic
{
    Manager manager = Manager.Instance;


    public void Run(Figure figure)
    {
        // Если ячейка рядом и нет другой фигуры
        if (CheckIsOneStepAround() && !Arrays.CheckIsOtherFigure())
        {
            RemoveFromArray(figure);
            SnapFigure(figure);
            return;
        }
        
        
        
        // Курсор на враге
        if (CheckIsEnemyFigure(Utils.GetRoundMousePosition()))
        {
            Debug.Log("Входит во врага");
            BackToCurrentPosition(figure);
            return;
        }
        
        // Противник по вертикали и горизонтали
        // if (CheckIsTwoStepAround())
        // {
        //     Debug.Log("Курсор на расстояние двух клеток");
        //     // RemoveFromArray(figure);
        //     // SnapFigure(figure);
        //     BackToCurrentPosition(figure);
        // }
        
        else
        {
            BackToCurrentPosition(figure);
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


    private bool CheckIsTwoStepAround()
    {
        var a = Arrays.GetDoubleMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), a);
    }


    // Получить массив 4х координат по вертикали и горизонтали
    private Tuple<int, int>[] GetHorizontalAndVerticalElements()
    {
        var m = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        var fourCoordinates = new Tuple<int, int>[]{m[0,1], m[2,1], m[1,0], m[1,2]};
        
        return fourCoordinates;
    }


    private bool CheckIsEnemyFigure(Tuple<int, int> coordinates)
    {
        var array = Arrays.figures;

        if (coordinates.Item1 < 0 || coordinates.Item1 >= array.GetLength(0) ||
            coordinates.Item2 < 0 || coordinates.Item2 >= array.GetLength(1))
        {
            return false;
        }

        if (Arrays.figures[coordinates.Item1, coordinates.Item2] == null) return false;

        return Arrays.figures[coordinates.Item1, coordinates.Item2].PlayerType != manager.CurrentPlayer;
    }
    
    
    // У координаты получить:
    // - есть ли фигура
    // - противник? тип игрока
    // - стоит ли фигура в одной из 4х координат





    // Сравнивает две координаты, отдает 
    // void
}