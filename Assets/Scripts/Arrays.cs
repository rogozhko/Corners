using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays
{
    private static Manager manager = Manager.Instance;


    public static Figure[,] figures = new Figure[8, 8];


    #region StartPlayersPosition

    public static Tuple<int, int>[] playerOneFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(5, 0), new Tuple<int, int>(6, 0), new Tuple<int, int>(7, 0),
        new Tuple<int, int>(5, 1), new Tuple<int, int>(6, 1), new Tuple<int, int>(7, 1),
        new Tuple<int, int>(5, 2), new Tuple<int, int>(6, 2), new Tuple<int, int>(7, 2)
    };

    public static Tuple<int, int>[] playerTwoFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(0, 5), new Tuple<int, int>(0, 6), new Tuple<int, int>(0, 7),
        new Tuple<int, int>(1, 5), new Tuple<int, int>(1, 6), new Tuple<int, int>(1, 7),
        new Tuple<int, int>(2, 5), new Tuple<int, int>(2, 6), new Tuple<int, int>(2, 7)
    };

    #endregion

    

    #region Matrix

    public static Tuple<int, int>[,] GetMatrixAroundFigure(Tuple<int, int> coordinates)
    {
        Tuple<int, int>[,] matrixAround = new Tuple<int, int>[3, 3];

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                matrixAround[i, j] = new Tuple<int, int>(coordinates.Item1 + i - 1, coordinates.Item2 + j - 1);
            }
        }
        
        return matrixAround;
    }

    public static Tuple<int, int>[,] GetDoubleMatrixAroundFigure(Tuple<int, int> coordinates)
    {
        Tuple<int, int>[,] matrixAround = new Tuple<int, int>[5, 5];

        for (int i = 0; i < matrixAround.GetLength(0); i++)
        {
            for (int j = 0; j < matrixAround.GetLength(1); j++)
            {
                matrixAround[i, j] = new Tuple<int, int>(coordinates.Item1 + i - 2, coordinates.Item2 + j - 2);
            }
        }
        
        return matrixAround;
    }

    public static bool CheckIsBelongToMatrix(Tuple<int, int> coordinates, Tuple<int, int>[,] matrix)
    {
        foreach (var tuple in matrix)
        {
            if (Equals(tuple, coordinates)) return true;
        }

        return false;
    }

    public static bool CheckIsOtherFigure()
    {
        var mousePosition = Utils.GetRoundMousePosition();
        return figures[mousePosition.Item1, mousePosition.Item2] != null;
    }
    
    public static bool CheckIsEnemyFigure(Tuple<int, int> coordinates)
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

    #endregion


    public static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
    {
        for (int i = 0; i < matrix.GetLength(0); ++i)
        {
            for (int j = 0; j < matrix.GetLength(1); ++j)
            {
                if (matrix[i, j] == null) continue;
                if (!matrix[i, j].Equals(value)) continue;
                return Tuple.Create(i, j);
            }
        }

        return Tuple.Create(-1, -1);
    }

    #region Debug

    public static void ShowMatrix(Tuple<int, int>[,] matrix)
    {
        Debug.Log("_____________________________");
        Debug.Log($"{matrix[0, 0]} {matrix[0, 1]} {matrix[0, 2]}");
        Debug.Log($"{matrix[1, 0]} {matrix[1, 1]} {matrix[1, 2]}");
        Debug.Log($"{matrix[2, 0]} {matrix[2, 1]} {matrix[2, 2]}");
        Debug.Log("_____________________________");
    }

    #endregion
}