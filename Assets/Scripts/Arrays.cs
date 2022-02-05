using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrays
{
    private Manager manager = Manager.Instance;


    public static Figure[,] figures = new Figure[8,8];


    #region StartPlayersPosition

    public static Tuple<int, int>[] playerOneFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(5,0), new Tuple<int, int>(6,0), new Tuple<int, int>(7,0),
        new Tuple<int, int>(5,1), new Tuple<int, int>(6,1), new Tuple<int, int>(7,1),
        new Tuple<int, int>(5,2), new Tuple<int, int>(6,2), new Tuple<int, int>(7,2)
    };

    public static Tuple<int, int>[] playerTwoFigureCoordinates = new Tuple<int, int>[]
    {
        new Tuple<int, int>(0,5), new Tuple<int, int>(0,6), new Tuple<int, int>(0,7),
        new Tuple<int, int>(1,5), new Tuple<int, int>(1,6), new Tuple<int, int>(1,7),
        new Tuple<int, int>(2,5), new Tuple<int, int>(2,6), new Tuple<int, int>(2,7)
    };

    #endregion


    public static bool CheckIsCoordinatesAvaible()
    {
        var mousePosition = Utils.GetRoundMousePosition();
        return figures[mousePosition.Item1, mousePosition.Item2] != null;
    }
    
    public static bool CheckIsWin(Player player)
    {
        return CountOfCurrentPlayerFiguresInEnemyField(player) == 9;
    }

    public static int CountOfCurrentPlayerFiguresInEnemyField(Player currentPlayer)
    {
        var count = 0;
        var currentPlayerFigures = new List<Figure>();
        Tuple<int, int>[] opponentCoordinates;

        opponentCoordinates = currentPlayer == Player.One ? playerTwoFigureCoordinates : playerOneFigureCoordinates;

        var w = figures.GetLength(0); // width
        var h = figures.GetLength(1); // height
        
        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (figures[x, y] == null) continue;
                if (figures[x, y].PlayerType == currentPlayer)
                {
                    currentPlayerFigures.Add(figures[x,y]);
                }
            }
        }

        foreach (var figure in currentPlayerFigures)
        {
            foreach (var t in opponentCoordinates)
            {
                if (Equals(figure.Coordinates, t))
                {
                    count++;
                }
            }
        }
        return count;
    }
    
    public static Tuple<int, int> CoordinatesOf<T>(T[,] matrix, T value)
    {
        var w = matrix.GetLength(0); // width
        var h = matrix.GetLength(1); // height

        for (int x = 0; x < w; ++x)
        {
            for (int y = 0; y < h; ++y)
            {
                if (matrix[x, y] == null) continue;
                if (!matrix[x, y].Equals(value)) continue;
                return Tuple.Create(x, y);
            }
        }

        return Tuple.Create(-1, -1);
    }
}