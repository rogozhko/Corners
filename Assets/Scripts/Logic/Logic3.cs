using System;
using UnityEngine;

public class Logic3 : ILogic
{
    // Логика работы игры когда ходим только на одну клетку


    Manager manager = Manager.Instance;
    

    public (bool, Tuple<int,int>) CheckIsNextOfEnemyFigure()
    {
        var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);

        var upCell = coordinatesAroundFigure[0, 1];
        var dowCell = coordinatesAroundFigure[2, 1];
        var lefCell = coordinatesAroundFigure[1, 0];
        var rightCell = coordinatesAroundFigure[1, 2];


        if (CheckIsEnemyFigure(upCell) && upCell.Equals(Utils.GetRoundMousePosition()))
        {
            var nextCoordinate = new Tuple<int, int>(upCell.Item1 - 1, upCell.Item2);
            Debug.Log($"Enemy on {upCell}");
            return (true, nextCoordinate);
        }

        // if (CheckIsEnemyFigure(dowCell))
        // {
        //     var nextCoordinate = new Tuple<int, int>(dowCell.Item1 + 1, dowCell.Item2);
        //     Debug.Log($"Enemy on {dowCell}");
        //     return true;
        // }
        //
        // if (CheckIsEnemyFigure(lefCell))
        // {
        //     var nextCoordinate = new Tuple<int, int>(lefCell.Item1, lefCell.Item2 - 1);
        //     return true;
        // }
        //
        // if (CheckIsEnemyFigure(rightCell))
        // {
        //     var nextCoordinate = new Tuple<int, int>(rightCell.Item1, rightCell.Item2 + 1);
        //     return true;
        // }

        return (false, null);
    }

    private bool CheckIsEnemyFigure(Tuple<int, int> coord)
    {
        var array = Arrays.figures;

        // Debug.Log($"{coord.Item1} {coord.Item2}");

        if (coord.Item1 < 0 || coord.Item1 >= array.GetLength(0) || 
        coord.Item2 < 0 || coord.Item2 >= array.GetLength(1))
        {
            return false;
        }
        
        if (Arrays.figures[coord.Item1, coord.Item2] == null) return false;
        
        // Debug.Log(Arrays.figures[coord.Item1, coord.Item2]);
        
        if (Arrays.figures[coord.Item1, coord.Item2].PlayerType == manager.CurrentPlayer)
        {
            return false;
        }
        else
        {
            return true;
        }

    }


    public bool CheckIsOneCellAround()
    {
        var coordinatesAroundFigure = Arrays.GetMatrixAroundFigure(manager.CurrentFigure.Coordinates);
        // Arrays.ShowMatrix(coordinatesAroundFigure);

        return Arrays.CheckIsBelongToMatrix(Utils.GetRoundMousePosition(), coordinatesAroundFigure);
    }
}