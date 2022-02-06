using System;
using System.Collections.Generic;

public static class WinLogic
{
    public static bool CheckIsWin(Player player)
    {
        return CountFiguresInEnemyField(player) == DataHolder.WinCount;
    }


    // Подумать
    public static int CountFiguresInEnemyField(Player currentPlayer)
    {
        var count = 0;
        var currentPlayerFigures = new List<Figure>();

        var opponentCoordinates = currentPlayer == Player.One
            ? Arrays.playerTwoFigureCoordinates
            : Arrays.playerOneFigureCoordinates;

        for (int i = 0; i < Arrays.figures.GetLength(0); ++i)
        {
            for (int j = 0; j < Arrays.figures.GetLength(1); ++j)
            {
                if (Arrays.figures[i, j] == null) continue;
                if (Arrays.figures[i, j].PlayerType == currentPlayer)
                {
                    currentPlayerFigures.Add(Arrays.figures[i, j]);
                }
            }
        }

        foreach (var coordinates in currentPlayerFigures)
        {
            foreach (var t in opponentCoordinates)
            {
                if (Equals(coordinates.Coordinates, t))
                {
                    count++;
                }
            }
        }

        return count;
    }

    
}