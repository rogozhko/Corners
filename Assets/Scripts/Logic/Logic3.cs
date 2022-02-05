using System;
using UnityEngine;

public class Logic3 : ILogic
{
    Manager manager = Manager.Instance;


    public void Run(Figure figure)
    {
        if (CheckIsMoveOneCell())
        {
            RemoveFromArray(figure);
            SnapFigure(figure);
        }

        // Входит ли позиция курсора в ячейку фигура + 2 и есть ли в фигура + 1 враг
        if (SecondLogic().Item1)
        {
            Debug.Log("Входит во врага");
        }
        else
        {
            figure.transform.position = Utils.GetPositionFromCoordinates(figure.Coordinates);
        }
    }

    private bool CheckIsMoveOneCell()
    {
        var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        // Arrays.ShowMatrix(coordinatesAroundFigure);

        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), coordinatesAroundFigure);
    }

    #region Move

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


    public (bool, Tuple<int, int>) SecondLogic()
    {
        var nextEnemyCell = GetEnemyCoordinates();
        if (nextEnemyCell == Utils.GetRoundMousePosition())
        {
            Debug.Log("Сюда можно походить");
            return (true, nextEnemyCell);
        }

        return (false, null);
    }

    private Tuple<int, int> GetEnemyCoordinates()
    {
        var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);

        var upCell = coordinatesAroundFigure[0, 1];
        var dowCell = coordinatesAroundFigure[2, 1];
        var lefCell = coordinatesAroundFigure[1, 0];
        var rightCell = coordinatesAroundFigure[1, 2];

        // if (CheckIsEnemyFigure(upCell))
        // {
        //     var nextCoordinate = new Tuple<int, int>(upCell.Item1 - 1, upCell.Item2);
        //     return (nextCoordinate);
        // }

        if (CheckIsEnemyFigure(upCell)) ReturnNextCell(upCell, (-1, 0));
        if (CheckIsEnemyFigure(dowCell)) ReturnNextCell(dowCell, (1, 0));

        

        return (null);
    }

    private Tuple<int, int> ReturnNextCell(Tuple<int, int> cellCoordinate, (int x, int y) increase)
    {
        var nextCoordinate = new Tuple<int, int>(cellCoordinate.Item1 + increase.x, cellCoordinate.Item1 + increase.y);
        return (nextCoordinate);
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

        if (Arrays.figures[coordinates.Item1, coordinates.Item2].PlayerType == manager.CurrentPlayer)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}